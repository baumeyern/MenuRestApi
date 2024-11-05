using MenuApi.Models;

namespace MenuApi.Repositories.Interfaces;

public interface IMenuItemRepository
{
    IEnumerable<MenuItem> GetAllMenuItems();
    MenuItem? GetMenuItemByName(string name);
    MenuItem? GetMenuItemById(Guid id);
    MenuItem CreateMenuItem(MenuItem menuItem);
    MenuItem UpdateMenuItem(MenuItem menuItem);
    void DeleteMenuItem(MenuItem menuItem);
}