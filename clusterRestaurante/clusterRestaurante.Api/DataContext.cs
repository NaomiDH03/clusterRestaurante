using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes{ get; set; }

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>().HasIndex(x => x.Name).IsUnique(); //Para que no haya valores repetidos
            modelBuilder.Entity<Dish>().HasIndex(x => x.Name).IsUnique(); //Para que no haya valores repetidos
            modelBuilder.Entity<Menu>().HasIndex(x => x.Name).IsUnique(); //Para que no haya valores repetidos
        }
    }
}
