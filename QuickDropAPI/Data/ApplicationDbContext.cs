using Microsoft.EntityFrameworkCore;
using QuickDropAPI.Models;
namespace QuickDropAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

    }
}
