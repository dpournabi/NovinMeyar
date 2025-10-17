using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.IdentityServer.DataLayer;
using NovinMeyar.IdentityServer.Domain.Entities;
using NovinMeyar.Common;

namespace NovinMeyar.IdentityServer.Server.Services.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public ProfileService(UserManager<ApplicationUser> userManager, 
                              IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, 
                              ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.claimsFactory = claimsFactory;
            this.dbContext = dbContext;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            var principal = await claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            var branch = dbContext.Branches.Find(user.BranchId);
            var query = (from r in dbContext.Roles
                        join ur in dbContext.UserRoles on r.Id equals ur.RoleId
                        select new { ur.UserId, RoleName = r.Name, RoleId = r.Id  })
                        .AsQueryable();
            var userRoleIds = query.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            var userPermissions = await dbContext.UserClaims.Where(x => x.UserId == user.Id && x.ClaimType=="Permission").Select(x => x.ToClaim()).ToListAsync();
            var rolePermissions = await dbContext.RoleClaims.Where(x => userRoleIds.Contains(x.RoleId) && x.ClaimType == "Permission").Select(x=> x.ToClaim()).ToListAsync();

            bool currentRoleIsRoot = query.Any(x => x.UserId == user.Id && x.RoleName == AssessorsManager.Root);
            bool CurrentRoleIsAdmin = query.Any(x => x.UserId == user.Id && (x.RoleName == AssessorsManager.Administrator || x.RoleName == AssessorsManager.TechnicalManager));
            var userRoles = string.Join(",", query.Where(x => x.UserId == user.Id).Select(x => x.RoleName).ToList());
            var companyInfo = await dbContext.UserClaims
                                                .Where(x => x.UserId == user.Id && 
                                                            (x.ClaimType == "InstallationCompanyId" || x.ClaimType == "InstallationCompanyName")
                                                       )
                                                .Select(x => x.ToClaim())
                                                .ToListAsync();

            if (branch!=null)
            {
                claims.Add(new Claim("BranchId", branch.Id.ToString()));
                claims.Add(new Claim("BranchName", branch.Name));
                claims.Add(new Claim("BranchCode", branch.Code));

                var currentBranchUserIds = await dbContext.UserClaims.Where(x => x.ClaimType == "BranchId" && x.ClaimValue==branch.Id.ToString()).Select(x => x.UserId).ToListAsync();
                var currentBranchUsers = await dbContext.Users.Where(x => currentBranchUserIds.Contains(x.Id)).Select(x => x.UserName).ToListAsync();
                claims.Add(new Claim("CurrentBranchUsers", string.Join(",", currentBranchUsers)));
            }
            
            claims.Add(new Claim("UserName", user.UserName));
            claims.Add(new Claim("CurrentUserRoles", userRoles));
            claims.Add(new Claim("CurrentRoleIsRoot", currentRoleIsRoot.ToString()));
            claims.Add(new Claim("CurrentRoleIsAdmin", CurrentRoleIsAdmin.ToString()));
            claims.Add(new Claim("FirstName", user.FirstName));
            claims.Add(new Claim("LastName", user.LastName));
            claims.Add(new Claim("DateOfBirth", user.DateOfBirth.ToString() ?? string.Empty));
            claims.Add(new Claim("IsActive", user.IsActive.ToString()));
            claims.AddRange(userPermissions);
            claims.AddRange(rolePermissions);

            if(companyInfo!=null && companyInfo.Any())
                claims.AddRange(companyInfo);

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
