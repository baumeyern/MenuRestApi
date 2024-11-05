using MenuApi.Models;
using MenuApi.Services.Interfaces;
using MenuApi.Repositories.Interfaces;

namespace MenuApi.Services;

public class MenuItemService: IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly ILogger<MenuItemService> _logger;
    
    public MenuItemService(IMenuItemRepository menuItemRepository, ILogger<MenuItemService> logger)
    {
        _menuItemRepository = menuItemRepository;
        _logger = logger;
    }
    
    public MenuItem AddMenuItem(MenuItem menuItem)
    {
        menuItem.Name = menuItem.Name.Trim();
        
        if (menuItem.Name.Length == 0)
        {
            _logger.LogError("Cannot add menu item with empty name");
            throw new InvalidOperationException("Cannot add menu item with empty name");
        }

        if (_menuItemRepository.GetMenuItemByName(menuItem.Name) != null)
        {
            _logger.LogError("Menu item with this name already exists");
            throw new InvalidOperationException("Menu item with this name already exists");
        }

        return _menuItemRepository.CreateMenuItem(menuItem);
    }
    
    public IEnumerable<MenuItem> GetMenuItems()
    {
        return _menuItemRepository.GetAllMenuItems();
    }

    public MenuItem? GetMenuItem(Guid id)
    {
        try
        {
            return _menuItemRepository.GetMenuItemById(id);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Failed to get menu item by Id");
            return null;
        }
    }

    public MenuItem UpdateMenuItem(MenuItem menuItem)
    {
        menuItem.Name = menuItem.Name.Trim();
        
        if (menuItem.Name.Length == 0)
        {
            _logger.LogError("Cannot update menu item with empty name");
            throw new InvalidOperationException("Cannot update menu item with empty name");
        }

        if (_menuItemRepository.GetMenuItemById(menuItem.Id) == null)
        {
            throw new KeyNotFoundException("Menu item with this id does not exist");
        }
        
        var existingMenuItem = _menuItemRepository.GetMenuItemById(menuItem.Id);
        if (existingMenuItem != null && existingMenuItem.Id != menuItem.Id)
        {
            _logger.LogError("Menu item with this name already exists");
            throw new InvalidOperationException("Menu item with this name already exists");
        }
        
        return _menuItemRepository.UpdateMenuItem(menuItem);
    }

    public void DeleteMenuItem(MenuItem menuItem)
    {
        try
        {
            _menuItemRepository.DeleteMenuItem(menuItem);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete menu item");
        }
    }
}