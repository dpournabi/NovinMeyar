using Audit.Core;
using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NovinMeyar.Cartabl.Domain.Entities;
using NovinMeyar.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.DataLayer
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
                                        .Map<Request, AuditLog>((request, audit) =>
                                        {
                                            audit.TableName = nameof(Request);
                                            audit.TablePK = request.Id.ToString();
                                            audit.Data = Newtonsoft.Json.JsonConvert.SerializeObject(request,settings);
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

        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<AttachmentType> AttachmentTypes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RequestAttachment> RequestAttachments { get; set; }

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
