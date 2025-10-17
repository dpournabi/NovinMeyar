using System;
using Audit.Core;
using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovinMeyar.Customer.Domain.Entities;

namespace NovinMeyar.Customer.DataLayer
{
    public class DataContext : DbContext
    {
        private static DbContextHelper _helper = new DbContextHelper();
        private readonly IAuditDbContext _auditContext;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            _auditContext = new Audit.EntityFramework.DefaultAuditContext(this);
            _helper.SetConfig(_auditContext);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            Audit.Core.Configuration.Setup()
                                    .UseEntityFramework(ef => ef
                                    .AuditTypeExplicitMapper(m => m
                                        .Map<RealCustomer, AuditLog>((request, audit) =>
                                        {
                                            audit.TableName = nameof(RealCustomer);
                                            audit.TablePK = request.Id.ToString();
                                            audit.Data = JsonConvert.SerializeObject(request, settings);
                                        })
                                        .Map<LegalCustomer, AuditLog>((request, audit) =>
                                        {
                                            audit.TableName = nameof(LegalCustomer);
                                            audit.TablePK = request.Id.ToString();
                                            audit.Data = JsonConvert.SerializeObject(request, settings);
                                        })
                                        .AuditEntityAction<AuditLog>((evt, entry, auditEntity) =>
                                        {
                                            auditEntity.AuditDate = DateTime.UtcNow;
                                            auditEntity.AuditUser = evt.Environment.UserName;
                                            auditEntity.AuditAction = entry.Action; // Insert, Update, Delete
                                        })
                                      )
                                      .IgnoreMatchedProperties(true));
        }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<LegalCustomer> LegalCustomers { get; set; }
        public DbSet<RealCustomer> RealCustomers { get; set; }

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