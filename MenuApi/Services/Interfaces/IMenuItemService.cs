using MenuApi.Models;

namespace MenuApi.Services.Interfaces;

public interface IMenuItemService
{
    MenuItem AddMenuItem(MenuItem menuItem);
    IEnumerable<MenuItem> GetMenuItems();
    MenuItem? GetMenuItem(Guid id);
    MenuItem UpdateMenuItem(MenuItem menuItem);
    void DeleteMenuItem(MenuItem menuItem);
}