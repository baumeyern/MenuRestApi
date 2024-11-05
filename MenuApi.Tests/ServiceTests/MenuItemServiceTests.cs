using FluentAssertions;
using MenuApi.Models;
using MenuApi.Repositories.Interfaces;
using MenuApi.Services;
using Moq;

namespace MenuApi.Tests.ServiceTests;

[TestClass]
public class MenuItemServiceTests
{
    private readonly MenuItemService _menuItemService;
    private readonly Mock<IMenuItemRepository> _menuItemRepositoryMock;

    public MenuItemServiceTests()
    {
        _menuItemRepositoryMock = new Mock<IMenuItemRepository>();
        _menuItemService = new MenuItemService(_menuItemRepositoryMock.Object, null);
    }

    [TestMethod]
    public void GetMenuItem_ShouldReturnMenuItem_WhenMenuItemExists()
    {
        var itemId = Guid.NewGuid();
        var item = new MenuItem { Id = itemId, Name = "Test" };
        _menuItemRepositoryMock.Setup(repository => repository.GetMenuItemById(itemId)).Returns(item);

        var result = _menuItemService.GetMenuItem(itemId);

        result.Should().NotBeNull();
        result!.Id.Should().Be(itemId);
    }

    [TestMethod]
    public void GetMenuItem_ShouldReturnNull_WhenMenuItemDoesNotExists()
    {
        var itemId = Guid.NewGuid();
        _menuItemRepositoryMock.Setup(repository => repository.GetMenuItemById(itemId)).Returns((MenuItem)null!);

        var result = _menuItemService.GetMenuItem(itemId);

        result.Should().BeNull();
    }
}