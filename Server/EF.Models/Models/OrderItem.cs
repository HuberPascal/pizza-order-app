namespace EF.Models.Models;

public class OrderItem
{
    // Primary Key
    public Guid Id { get; set; }
    
    // Foreign Keys
    public Guid OrderId { get; set; }
    public Guid PizzaId { get; set; }
    
    // Properties
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string? SpecialInstructions { get; set; }
    
    // Calculated Property
    public decimal TotalPrice { get; set; }
    
    // Navigation Properties
    public virtual Order Order { get; set; }
    public virtual Pizza Pizza { get; set; }
    public List<ExtraTopping> ExtraToppings { get; set; } = new List<ExtraTopping>();
}