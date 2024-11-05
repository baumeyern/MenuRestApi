using MenuApi.Models;
using MenuApi.Models.Requests;
using MenuApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }
    
    /// <summary>
    /// Creates a new menu item
    /// </summary>
    /// <param name="request">Object containing details for the menu item</param>
    /// <returns>
    /// A status code that indicates the result of the operation.
    /// </returns>
    /// <response code="200">A menu item was created successfully</response>
    /// <response code="400">A bad request was provided</response>
    [HttpPost]
    public ActionResult<MenuItem> CreateMenuItem([FromBody] MenuItemRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var menuItem = new MenuItem()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price ?? 5, //Should really be getting a default price from some kind of config
            Category = request.Category ?? Category.Unknown,
            LastUpdated = DateTime.Now
        };

        try
        {
            return Ok(_menuItemService.AddMenuItem(menuItem));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves all the menu items available on the menu.
    /// </summary>
    /// <returns>
    /// A list of all the menu items in the database.
    /// </returns>
    /// <response code="200">A list of menu items was returned successfully</response>
    /// <response code="204">No menu items were found on the menu</response>
    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> GetMenuItems()
    {
        return Ok(_menuItemService.GetMenuItems());
    }

    /// <summary>
    /// Retrieves a menu item by its ID.
    /// </summary>
    /// <param name="id">ID of the menu item</param>
    /// <returns>
    /// The details of a menu item if found, or a 404 if the menu item is not found.
    /// </returns>
    /// <response code="200">A menu item is found and returned successfully</response>
    /// <response code="404">A menu item with a matching ID was not found</response>
    [HttpGet("{id:guid}")]
    public ActionResult<MenuItem> GetMenuItem(Guid id)
    {
        var menuItem = _menuItemService.GetMenuItem(id);

        if (menuItem == null)
        {
            return NotFound();
        }

        return Ok(menuItem);
    }
    
    /// <summary>
    /// Updates a menu item
    /// </summary>
    /// <param name="id">The unique ID of the menu item to update.</param>
    /// <param name="request">Object containing details for the menu item</param>
    /// <returns>
    /// A status code that indicates the result of the operation.
    /// </returns>
    /// <response code="200">A menu item was updated successfully</response>
    /// <response code="404">A menu item with a matching ID was not found</response>
    /// <response code="400">A bad request was provided</response>
    [HttpPut("{id:guid}")]
    public ActionResult<MenuItem> UpdateMenuItem(Guid id, [FromBody] MenuItemRequest request)
    {
        var existingMenuItem = _menuItemService.GetMenuItem(id);
        
        if (existingMenuItem == null)
            return NotFound();

        existingMenuItem.Name = request.Name;
        existingMenuItem.Description = request.Description;
        existingMenuItem.LastUpdated = DateTime.Now;
        if(request.Price != null)
            existingMenuItem.Price = request.Price.Value;

        if (request.Category != null)
        {
            existingMenuItem.Category = Enum.IsDefined(typeof(Category), request.Category) ? 
                request.Category.Value : 
                Category.Unknown;
        }

        try
        {
            return Ok(_menuItemService.UpdateMenuItem(existingMenuItem));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Deletes a menu item
    /// </summary>
    /// <param name="id">The unique ID of the menu item to delete.</param>
    /// <returns>
    /// A status code that indicates the result of the operation.
    /// </returns>
    /// <response code="200">A menu item was deleted successfully</response>
    /// <response code="404">A menu item with a matching ID was not found</response>
    [HttpDelete("{id:guid}")]
    public ActionResult<MenuItem> DeleteMenuItem(Guid id)
    {
        var existingMenuItem = _menuItemService.GetMenuItem(id);
        
        if (existingMenuItem == null)
            return NotFound();

        try
        {
            _menuItemService.DeleteMenuItem(existingMenuItem);
            return Ok("Menu item deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}