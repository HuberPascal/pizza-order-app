using EF.Models.Enums;

namespace Core.Transports.Orders;

public class CreateOrderRequest
{
    public Guid UserId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string DeliveryAddress { get; set; }
    public string? CustomerNotes { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    
    public List<CreateOrderItemRequest> OrderItems { get; set; }
}