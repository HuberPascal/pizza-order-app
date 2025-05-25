namespace Core.Transports.Orders;

public class CreateOrderItemRequest
{
    public Guid PizzaId { get; set; }
    public int Quantity { get; set; }
    public List<Guid> ExtraToppingIds { get; set; }
    public string? SpecialInstructions { get; set; }
}