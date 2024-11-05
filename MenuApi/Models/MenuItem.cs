namespace MenuApi.Models;

public class MenuItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public DateTime LastUpdated { get; set; }
}