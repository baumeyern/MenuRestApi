using System.ComponentModel.DataAnnotations;

namespace MenuApi.Models.Requests;

public class MenuItemRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    public double? Price { get; set; }
    public Category? Category { get; set; }

}