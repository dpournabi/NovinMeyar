using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common.Domain.Entities;

namespace NovinMeyar.Common.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}