using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<MainCategories> MainCategories { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<RestaurantTables> RestaurantTables { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecipeRequirements> RecipeRequirements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MainCategories - SubCategories ilişkisi
            modelBuilder.Entity<SubCategories>()
                .HasOne(s => s.MainCategories)
                .WithMany(m => m.SubCategories)
                .HasForeignKey(s => s.MainCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // SubCategories - MenuItems ilişkisi
            modelBuilder.Entity<MenuItems>()
                .HasOne(m => m.SubCategories)
                .WithMany(s => s.MenuItems)
                .HasForeignKey(m => m.SubCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // RestaurantTables - Orders ilişkisi
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.RestaurantTables)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableID)
                .OnDelete(DeleteBehavior.Restrict);

            // Orders - OrderItems ilişkisi
            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.Orders)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            // MenuItems - OrderItems ilişkisi
            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.MenuItems)
                .WithMany(m => m.OrderItems)
                .HasForeignKey(oi => oi.MenuItemID)
                .OnDelete(DeleteBehavior.Restrict);

            // MenuItems - RecipeRequirements ilişkisi
            modelBuilder.Entity<RecipeRequirements>()
                .HasOne(r => r.MenuItems)
                .WithMany(m => m.RecipeRequirements)
                .HasForeignKey(r => r.MenuItemID)
                .OnDelete(DeleteBehavior.Cascade);

            // Ingredients - RecipeRequirements ilişkisi
            modelBuilder.Entity<RecipeRequirements>()
                .HasOne(r => r.Ingredients)
                .WithMany(i => i.RecipeRequirements)
                .HasForeignKey(r => r.IngredientID)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal property configurations
            modelBuilder.Entity<MenuItems>()
                .Property(m => m.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders>()
                .Property(o => o.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderItems>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ingredients>()
                .Property(i => i.Quantity)
                .HasPrecision(10, 2);

            modelBuilder.Entity<RecipeRequirements>()
                .Property(r => r.RequiredQuantity)
                .HasPrecision(10, 2);
        }
    }
}