using Microsoft.EntityFrameworkCore;

namespace amsterdam.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<recommendation> recommendations { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Plane> planes { get; set; }
    }
}
