using EF.Models.Enums;

namespace Core.Transports.Orders;

public class ChangeOrderStatusRequest
{
    public OrderStatus Status { get; set; }
}