using System;
using System.Threading;
using System.Threading.Tasks;
using Audit.Core;
using Audit.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Domain.Models;
using NovinMeyar.IdentityServer.Domain.Entities;

namespace NovinMeyar.IdentityServer.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, UserClaim, UserRole,UserLogin,RoleClaim,UserToken>
    {
        private static DbContextHelper _helper = new DbContextHelper();
        private readonly IAuditDbContext _auditContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _auditContext = new Audit.EntityFramework.DefaultAuditContext(this);
            _helper.SetConfig(_auditContext);

            Audit.Core.Configuration.Setup()
                                    .UseEntityFramework(ef => ef
                                        .AuditTypeExplicitMapper(m => m
                                            .Map<ApplicationUser, AuditLog>((user, audit) =>
                                            {
                                                // Action for User -> AuditLog
                                                audit.TableName = "AspNetUsers";
                                                audit.TablePK = user.Id.ToString();
                                            })
                                            .Map<ApplicationRole, AuditLog>((role, audit) =>
                                            {
                                                // Action for Role -> AuditLog
                                                audit.TableName = "AspNetRoles";
                                                audit.TablePK = role.Id.ToString();
                                            })

                                            .AuditEntityAction<AuditLog>((evt, entry, audit) =>
                                            {
                                                // Common action on AuditLog
                                                audit.AuditDate = DateTime.UtcNow;
                                                audit.AuditAction = entry.Action;
                                                audit.AuditUser = Environment.UserName;
                                            }))
                                            .IgnoreMatchedProperties(true));
        }

        public new DbSet<ApplicationUser> Users { get; set; }
        public new DbSet<ApplicationRole> Roles { get; set; }
        public new DbSet<UserRole> UserRoles { get; set; }
        public new DbSet<UserClaim> UserClaims { get; set; }
        public new DbSet<UserToken> UserTokens { get; set; }
        public new DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }

        public override int SaveChanges()
        {
            return _helper.SaveChanges(_auditContext, () => base.SaveChanges());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _helper.SaveChangesAsync(_auditContext, () => base.SaveChangesAsync(cancellationToken));
        }
    }
}

