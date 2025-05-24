using EF.Models.Enums;

namespace EF.Models.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string DeliveryAddress { get; set; }
    public string? CustomerNotes { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaid { get; set; } = false;
    public DateTime? EstimatedDeliveryTime { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public virtual User? User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}