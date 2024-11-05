using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MenuApi.DbContexts.Interfaces;
using MenuApi.Models;

namespace MenuApi.DbContexts;

public class MenuContext : DbContext, IMenuContext
{
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {
    }

    public DbSet<MenuItem> MenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Category)
            .HasConversion<string>();

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem
            {
                Id = Guid.Parse("7c5b8a6f-6bb4-4f2a-92d8-31e29c6b9f5e"),
                Name = "Caesar Salad",
                Description = "Crisp romaine with Caesar dressing, croutons, and Parmesan cheese",
                Price = 8.99,
                Category = Category.Salad,
                LastUpdated = new DateTime(2024, 09, 09)
            },
            new MenuItem
            {
                Id = Guid.Parse("97d516e2-5e3e-45b6-b56f-1b09cf3db530"),
                Name = "Spaghetti Bolognese",
                Description = "Classic spaghetti pasta with rich, slow-cooked Bolognese sauce",
                Price = 14.99,
                Category = Category.Entree,
                LastUpdated = new DateTime(2024, 10, 09)
            },
            new MenuItem
            {
                Id = Guid.Parse("d8f0f80e-8d5c-4b69-9d58-6fbb2cb6c9c4"),
                Name = "Garlic Bread",
                Description = "Warm, toasted bread with garlic butter and herbs",
                Price = 4.99,
                Category = Category.Side,
                LastUpdated = new DateTime(2024, 10, 10)
            },
            new MenuItem
            {
                Id = Guid.Parse("45b8c3e9-6f8b-49e1-bc4d-9a1d123e5291"),
                Name = "Margherita Pizza",
                Description = "Classic pizza with fresh mozzarella, tomatoes, and basil",
                Price = 12.99,
                Category = Category.Entree,
                LastUpdated = new DateTime(2024, 10, 11)
            },
            new MenuItem
            {
                Id = Guid.Parse("3cfa65f9-1d92-4488-a558-f4dc9815db2c"),
                Name = "Chocolate Lava Cake",
                Description = "Decadent chocolate cake with a molten chocolate center",
                Price = 6.99,
                Category = Category.Dessert,
                LastUpdated = new DateTime(2024, 10, 12)

            },
            new MenuItem
            {
                Id = Guid.Parse("9b7d62a4-7e22-49c5-8c3f-15d739f8b09b"),
                Name = "Chicken Wings",
                Description = "Spicy chicken wings with a side of blue cheese dressing",
                Price = 10.99,
                Category = Category.Appetizer,
                LastUpdated = new DateTime(2024, 10, 13)

            },
            new MenuItem
            {
                Id = Guid.Parse("4e8db7b9-f3f1-48f9-91a2-77c5b7bfb17b"),
                Name = "Grilled Salmon",
                Description = "Perfectly grilled salmon with a lemon butter sauce",
                Price = 18.99,
                Category = Category.Entree,
                LastUpdated = new DateTime(2024, 10, 14)

            },
            new MenuItem
            {
                Id = Guid.Parse("15e5b967-8d42-4b6d-b963-c4f041745d3d"),
                Name = "Apple Pie",
                Description = "Classic apple pie with a hint of cinnamon and vanilla ice cream",
                Price = 5.99,
                Category = Category.Dessert,
                LastUpdated = new DateTime(2024, 10, 15)
            }
        );
    }
}