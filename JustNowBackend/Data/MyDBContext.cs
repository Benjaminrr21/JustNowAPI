using JustNowBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OwnerRestaurant> Owners { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<UserRestaurantGrades> Grades { get; set; }




        public MyDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRestaurantGrades>().HasKey(ur => new { ur.RestaurantId, ur.UserId });
            modelBuilder.Entity<UserRestaurantGrades>()
                .HasOne<User>(ur => ur.User)
                .WithMany(r => r.Grades)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<UserRestaurantGrades>()
                .HasOne<Restaurant>(ur => ur.Restaurant)
                .WithMany(r => r.Grades)
                .HasForeignKey(r => r.RestaurantId);
        }
    }
}
