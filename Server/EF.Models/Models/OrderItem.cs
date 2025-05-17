namespace EF.Models.Models;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid PizzaId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    public virtual Order Order { get; set; }
}