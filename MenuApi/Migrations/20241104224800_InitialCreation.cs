using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MenuApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "LastUpdated", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("15e5b967-8d42-4b6d-b963-c4f041745d3d"), "Dessert", "Classic apple pie with a hint of cinnamon and vanilla ice cream", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Pie", 5.9900000000000002 },
                    { new Guid("3cfa65f9-1d92-4488-a558-f4dc9815db2c"), "Dessert", "Decadent chocolate cake with a molten chocolate center", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate Lava Cake", 6.9900000000000002 },
                    { new Guid("45b8c3e9-6f8b-49e1-bc4d-9a1d123e5291"), "Entree", "Classic pizza with fresh mozzarella, tomatoes, and basil", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Margherita Pizza", 12.99 },
                    { new Guid("4e8db7b9-f3f1-48f9-91a2-77c5b7bfb17b"), "Entree", "Perfectly grilled salmon with a lemon butter sauce", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grilled Salmon", 18.989999999999998 },
                    { new Guid("7c5b8a6f-6bb4-4f2a-92d8-31e29c6b9f5e"), "Salad", "Crisp romaine with Caesar dressing, croutons, and Parmesan cheese", new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caesar Salad", 8.9900000000000002 },
                    { new Guid("97d516e2-5e3e-45b6-b56f-1b09cf3db530"), "Entree", "Classic spaghetti pasta with rich, slow-cooked Bolognese sauce", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spaghetti Bolognese", 14.99 },
                    { new Guid("9b7d62a4-7e22-49c5-8c3f-15d739f8b09b"), "Appetizer", "Spicy chicken wings with a side of blue cheese dressing", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Wings", 10.99 },
                    { new Guid("d8f0f80e-8d5c-4b69-9d58-6fbb2cb6c9c4"), "Side", "Warm, toasted bread with garlic butter and herbs", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garlic Bread", 4.9900000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
