﻿// <auto-generated />
using System;
using MenuApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MenuApi.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuApi.Models.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c5b8a6f-6bb4-4f2a-92d8-31e29c6b9f5e"),
                            Category = "Salad",
                            Description = "Crisp romaine with Caesar dressing, croutons, and Parmesan cheese",
                            LastUpdated = new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Caesar Salad",
                            Price = 8.9900000000000002
                        },
                        new
                        {
                            Id = new Guid("97d516e2-5e3e-45b6-b56f-1b09cf3db530"),
                            Category = "Entree",
                            Description = "Classic spaghetti pasta with rich, slow-cooked Bolognese sauce",
                            LastUpdated = new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Spaghetti Bolognese",
                            Price = 14.99
                        },
                        new
                        {
                            Id = new Guid("d8f0f80e-8d5c-4b69-9d58-6fbb2cb6c9c4"),
                            Category = "Side",
                            Description = "Warm, toasted bread with garlic butter and herbs",
                            LastUpdated = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Garlic Bread",
                            Price = 4.9900000000000002
                        },
                        new
                        {
                            Id = new Guid("45b8c3e9-6f8b-49e1-bc4d-9a1d123e5291"),
                            Category = "Entree",
                            Description = "Classic pizza with fresh mozzarella, tomatoes, and basil",
                            LastUpdated = new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Margherita Pizza",
                            Price = 12.99
                        },
                        new
                        {
                            Id = new Guid("3cfa65f9-1d92-4488-a558-f4dc9815db2c"),
                            Category = "Dessert",
                            Description = "Decadent chocolate cake with a molten chocolate center",
                            LastUpdated = new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chocolate Lava Cake",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = new Guid("9b7d62a4-7e22-49c5-8c3f-15d739f8b09b"),
                            Category = "Appetizer",
                            Description = "Spicy chicken wings with a side of blue cheese dressing",
                            LastUpdated = new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chicken Wings",
                            Price = 10.99
                        },
                        new
                        {
                            Id = new Guid("4e8db7b9-f3f1-48f9-91a2-77c5b7bfb17b"),
                            Category = "Entree",
                            Description = "Perfectly grilled salmon with a lemon butter sauce",
                            LastUpdated = new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Grilled Salmon",
                            Price = 18.989999999999998
                        },
                        new
                        {
                            Id = new Guid("15e5b967-8d42-4b6d-b963-c4f041745d3d"),
                            Category = "Dessert",
                            Description = "Classic apple pie with a hint of cinnamon and vanilla ice cream",
                            LastUpdated = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple Pie",
                            Price = 5.9900000000000002
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
