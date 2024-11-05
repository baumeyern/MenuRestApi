using MenuApi.Models;

namespace MenuApi.Services.Interfaces;

public interface IMenuItemService
{
    IEnumerable<MenuItem> GetMenuItems();
    MenuItem? GetMenuItem(Guid id);
    MenuItem AddMenuItem(MenuItem menuItem);
    MenuItem UpdateMenuItem(MenuItem menuItem);
    void DeleteMenuItem(MenuItem menuItem);
}