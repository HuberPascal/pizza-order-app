using System;

namespace Core.Transports.OrderItems;

public class OrderItemDto
{
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}