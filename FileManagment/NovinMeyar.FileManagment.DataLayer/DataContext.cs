using Microsoft.EntityFrameworkCore;
using NovinMeyar.FileManagment.Domain.Entities;

namespace NovinMeyar.FileManagment.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Stream> Streams { get; set; }
        public DbSet<DownloadLinkHistory> DownloadLinkHistories { get; set; }
    }
}