using Microsoft.EntityFrameworkCore;

namespace EFCoreRestauranteer.Models
{
    public class BasicDbContext : DbContext
    {
        public BasicDbContext(DbContextOptions<BasicDbContext> options) : base(options)
        {
            
        }

        public DbSet<Review> Reviews {get; set;}
    }
}