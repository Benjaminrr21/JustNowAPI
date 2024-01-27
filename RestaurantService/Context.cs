using Microsoft.EntityFrameworkCore;

namespace RestaurantService
{
    public class Context:DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public Context(DbContextOptions options) : base(options)
        {

        }

    }
}
