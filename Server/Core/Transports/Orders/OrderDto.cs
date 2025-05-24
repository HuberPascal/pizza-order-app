using System;

namespace Core.Transports.Orders;

public class OrderDto
{
    public decimal TotalPrice { get; set; }
    public string OrderStatus { get; set; }
}