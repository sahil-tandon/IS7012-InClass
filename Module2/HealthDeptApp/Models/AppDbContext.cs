using Microsoft.EntityFrameworkCore;
using HealthDeptApp.Models;

namespace HealthDeptApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<HealthDeptApp.Models.Establishment> Establishment { get; set; }
        public DbSet<HealthDeptApp.Models.Category> Category { get; set; }
    }
}