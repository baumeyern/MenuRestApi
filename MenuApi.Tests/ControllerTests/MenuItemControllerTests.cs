using FluentAssertions;
using MenuApi.Controllers;
using MenuApi.Models;
using MenuApi.Models.Requests;
using MenuApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MenuApi.Tests.ControllerTests;

[TestClass]
public class MenuItemControllerTests
{
    private readonly MenuItemController _controller;
    private readonly Mock<IMenuItemService> _menuItemServiceMock;

    public MenuItemControllerTests()
    {
        _menuItemServiceMock = new Mock<IMenuItemService>();
        _controller = new MenuItemController(_menuItemServiceMock.Object);
    }

    [TestMethod]
    public void GetMenuItem_ShouldReturnOk_WhenMenuItemExists()
    {
        var itemId = Guid.NewGuid();
        var item = new MenuItem { Id = itemId };
        _menuItemServiceMock.Setup(service => service.GetMenuItem(itemId)).Returns(item);

        var result = _controller.GetMenuItem(itemId);
        
        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result! as OkObjectResult;
        
        okResult!.Value.Should().BeOfType<MenuItem>();
        var itemResult = okResult.Value as MenuItem;
        
        item.Id.Should().Be(itemResult!.Id);
    }

    [TestMethod]
    public void GetMenuItem_ShouldReturnNotFound_WhenMenuItemDoesNotExists()
    {
        var itemId = Guid.NewGuid();
        _menuItemServiceMock.Setup(service => service.GetMenuItem(itemId)).Returns((MenuItem)null!);

        var result = _controller.GetMenuItem(itemId);

        result.Result.Should().BeOfType<NotFoundResult>();
    }


    [TestMethod]
    public void UpdateMenuItem_ShouldReturnOk_WhenMenuItemIsUpdated()
    {
        var itemId = Guid.NewGuid();
        var itemRequest = new MenuItemRequest() { Name = "Test", Description = "Test"};
        var item = new MenuItem { Id = itemId, Name = "Test", Description = "Test" };

        _menuItemServiceMock.Setup(service => service.GetMenuItem(itemId)).Returns(item);
        _menuItemServiceMock.Setup(service => service.UpdateMenuItem(It.IsAny<MenuItem>())).Returns(item);

        var result = _controller.UpdateMenuItem(itemId, itemRequest);

        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result! as OkObjectResult;
        
        okResult!.Value.Should().BeOfType<MenuItem>();
        var itemResult = okResult.Value as MenuItem;
        
        itemId.Should().Be(itemResult!.Id);
        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [TestMethod]
    public void UpdateMenuItem_ShouldReturnNotFound_WhenMenuItemDoesNotExists()
    {
        var itemId = Guid.NewGuid();
        var itemRequest = new MenuItemRequest() { Name = "Test", Description = "Test"};

        _menuItemServiceMock.Setup(service => service.GetMenuItem(itemId)).Returns((MenuItem)null!);

        var result = _controller.UpdateMenuItem(itemId, itemRequest);

        result.Result.Should().BeOfType<NotFoundResult>();
    }
}