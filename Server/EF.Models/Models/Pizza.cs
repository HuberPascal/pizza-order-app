
namespace EF.Models.Models;

public class Pizza
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsVegetarian { get; set; }
    public bool IsVegan { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string[] BaseIngredients { get; set; }
    
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}