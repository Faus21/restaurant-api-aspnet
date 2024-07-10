using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RestaurantApp.Models
{
    public class RestaurantDbContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDish> OrderDishes { get; set; }

        public DbSet<RestaurantWorker> restaurantWorkers { get; set; }

        public RestaurantDbContext() { }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
