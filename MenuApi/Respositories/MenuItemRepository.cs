using MenuApi.Models;
using MenuApi.DbContexts;
using MenuApi.DbContexts.Interfaces;
using MenuApi.Repositories.Interfaces;

namespace MenuApi.Repositories;

public class MenuItemRepository: IMenuItemRepository
{
    private readonly IMenuContext _dbContext;

    public MenuItemRepository(IMenuContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<MenuItem> GetAllMenuItems()
    {
        return _dbContext.MenuItems.ToList();
    }

    public MenuItem? GetMenuItemByName(string name)
    {
        return _dbContext.MenuItems.FirstOrDefault(item => item.Name == name);
    }

    public MenuItem? GetMenuItemById(Guid id)
    {
        return _dbContext.MenuItems.FirstOrDefault(item => item.Id == id);
    }

    public MenuItem CreateMenuItem(MenuItem menuItem)
    {
        var newItem = _dbContext.MenuItems.Add(menuItem);
        _dbContext.SaveChanges();
        return newItem.Entity;
    }

    public MenuItem UpdateMenuItem(MenuItem menuItem)
    {
        var updatedItem = _dbContext.MenuItems.Update(menuItem);
        _dbContext.SaveChanges();
        return updatedItem.Entity;    
    }

    public void DeleteMenuItem(MenuItem menuItem)
    {
        _dbContext.MenuItems.Remove(menuItem);
        _dbContext.SaveChanges();
    }
}