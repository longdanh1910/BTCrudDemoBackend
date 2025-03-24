using Microsoft.EntityFrameworkCore;
using TourWebApi.Models;

namespace TourWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
