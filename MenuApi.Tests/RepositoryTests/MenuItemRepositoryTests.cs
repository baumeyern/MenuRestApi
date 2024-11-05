using FluentAssertions;
using MenuApi.DbContexts;
using MenuApi.Models;
using MenuApi.Repositories;
using MenuApi.Repositories.Interfaces;
using MenuApi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MenuApi.Tests.RepositoryTests;

[TestClass]
public class MenuItemRepositoryTests
{
    private readonly MenuItemRepository _menuItemRepository;

    public MenuItemRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<MenuContext>()
            .UseInMemoryDatabase(databaseName: "MenuTestDb")
            .Options;

        var context = new MenuContext(options);
        _menuItemRepository = new MenuItemRepository(context);
    }

    //For repositories, just need to test writing to db
    [TestMethod]
    public void CreateMenuItem_ShouldAddItemToDb()
    {
        var menuItem = new MenuItem()
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test Description",
            Category = Category.Appetizer,
            Price = 10,
            LastUpdated = DateTime.Now
        };

        _menuItemRepository.CreateMenuItem(menuItem);
        
        var result = _menuItemRepository.GetMenuItemById(menuItem.Id);

        result.Should().NotBeNull();
        result.Name.Should().Be("Test");
        result.Description.Should().Be("Test Description");
        result.Category.Should().Be(Category.Appetizer);
        result.Price.Should().Be(10);
    }
}