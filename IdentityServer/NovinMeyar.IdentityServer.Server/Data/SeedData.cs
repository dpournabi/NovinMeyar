using System;
using System.Linq;
using NovinMeyar.Common;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovinMeyar.IdentityServer.DataLayer;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.EntityFramework.DbContexts;
using NovinMeyar.IdentityServer.Domain.Entities;
using NovinMeyar.IdentityServer.Domain;

namespace NovinMeyar.IdentityServer.Server.Data
{
    public class SeedData
    {
        private readonly IConfiguration configuration;
        private readonly IServiceScope serviceScope;
        private readonly ConfigurationDbContext configurationDbContext;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        #region Ctor
        public SeedData(IApplicationBuilder appBuilder, IConfiguration configuration)
        {
            this.configuration = configuration;
            serviceScope = appBuilder.ApplicationServices.CreateScope();
            configurationDbContext = serviceScope.ServiceProvider.GetService<ConfigurationDbContext>();
            roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        }
        #endregion

        #region Seed data
        void SeedClients()
        {
            foreach (var client in ClientStore.Get(configuration))
            {
                if (!configurationDbContext.Clients.Any(x => x.ClientId == client.ClientId))
                {
                    configurationDbContext.Clients.Add(client.ToEntity());
                }
            }
            configurationDbContext.SaveChanges();
        }
        void SeedIdentityResources()
        {
            if (!configurationDbContext.IdentityResources.Any())
            {
                foreach (var resource in ResourceStore.GetIdentityResources(configuration))
                    configurationDbContext.IdentityResources.Add(resource.ToEntity());

                configurationDbContext.SaveChanges();
            }
        }
        void SeedApiScopes()
        {
            if (!configurationDbContext.ApiScopes.Any())
            {
                foreach (var scope in ScopeStore.GetApiScopes(configuration))
                {
                    configurationDbContext.ApiScopes.Add(scope.ToEntity());
                }
                configurationDbContext.SaveChanges();
            }
        }
        void SeedApiResources()
        {
            if (!configurationDbContext.ApiResources.Any())
            {
                foreach (var resource in ResourceStore.GetApiResources(configuration))
                    configurationDbContext.ApiResources.Add(resource.ToEntity());

                configurationDbContext.SaveChanges();
            }
        }
        void SeedRoles()
        {
            var enumerator = DefaultData.DefaultRoles.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var role = enumerator.Current;
                if (!dbContext.Roles.Any(x => x.Name == role.Name))
                    dbContext.Roles.Add(role);
            }
            dbContext.SaveChanges();
        }
        void SeedBranches()
        {
            var enumerator = DefaultData.DefaultBranches.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var branch = enumerator.Current;
                if (!dbContext.Branches.Any(x => x.Code == branch.Code))
                    dbContext.Branches.Add(branch);
            }
            dbContext.SaveChanges();
        }
        async Task SeedUsersAsync()
        {
            var enumerator = DefaultData.DefaultUsers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var defaultUser = enumerator.Current;
                if (!await userManager.Users.AnyAsync(x => x.UserName == defaultUser.Username))
                {
                    var branch =await dbContext.Branches.FirstOrDefaultAsync(x => x.Code == defaultUser.BranchCode);
                    var user = new ApplicationUser
                    {
                        Id = Guid.NewGuid(),
                        UserName = defaultUser.Username,
                        FirstName = defaultUser.FirstName,
                        LastName = defaultUser.LastName,
                        DateOfBirth = defaultUser.DateOfBirth,
                        IsActive = defaultUser.IsActive,
                        BranchId = branch?.Id,
                        PhoneNumberConfirmed = true,
                        ConfirmationPhoneNumberCode = null
                    };

                    var result = await userManager.CreateAsync(user, defaultUser.Password);
                    ApplicationRole currentRole = await dbContext.Roles.FirstAsync(x => x.Name == defaultUser.Role);

                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);

                    await dbContext.UserRoles.AddAsync(new UserRole { RoleId = currentRole.Id, UserId = user.Id });
                    await dbContext.SaveChangesAsync();

                    if (branch != null)
                    {
                        await userManager.AddClaimAsync(user, new Claim("BranchName", branch.Name));
                        await userManager.AddClaimAsync(user, new Claim("BranchId", branch.Id.ToString()));
                    }

                    await userManager.AddClaimAsync(user, new Claim("FirstName", defaultUser.FirstName));
                    await userManager.AddClaimAsync(user, new Claim("LastName", defaultUser.LastName));
                    await userManager.AddClaimAsync(user, new Claim("RoleName", currentRole.Name));
                }
            }
        }
        async Task SeedRoleClaimsAsync()
        {
            var roles = await dbContext.Roles.Where(x => x.Name != AssessorsManager.Root && x.Name != AssessorsManager.Administrator && x.Name != AssessorsManager.Client).ToListAsync();
            foreach (var role in roles)
            {
                var enumerator = DefaultData.DefaultRoleClaims.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var cliamValue = enumerator.Current;
                    if (!await dbContext.RoleClaims.AnyAsync(x => x.RoleId == role.Id && x.ClaimValue == cliamValue))
                        await dbContext.RoleClaims.AddAsync(new RoleClaim { RoleId = role.Id, ClaimType = "Permission", ClaimValue = cliamValue });
                }
            }

            var clientRole = await dbContext.Roles.Where(x => x.Name == AssessorsManager.Client).FirstAsync();
            var clientEnumerator = DefaultData.DefaultRoleClaimsForClients.GetEnumerator();
            while (clientEnumerator.MoveNext())
            {
                var cliamValue = clientEnumerator.Current;
                if (!await dbContext.RoleClaims.AnyAsync(x => x.RoleId == clientRole.Id && x.ClaimValue == cliamValue))
                    await dbContext.RoleClaims.AddAsync(new RoleClaim { RoleId = clientRole.Id, ClaimType = "Permission", ClaimValue = cliamValue });
            }

            await dbContext.SaveChangesAsync();
        }
        #endregion

        public void SeedDefaultData()
        {
            SeedClients();
            SeedIdentityResources();
            SeedApiScopes();
            SeedApiResources();
            SeedRoles();
            SeedBranches();
            SeedUsersAsync().Wait();
            SeedRoleClaimsAsync().Wait();
        }
    }
}
