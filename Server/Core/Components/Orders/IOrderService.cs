using Core.Transports.Orders;
using EF.Models.Enums;

namespace Core.Components.Orders;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync(Guid employeeId, CancellationToken cancel);
    Task<OrderDto> GetOrderAsync(Guid orderId, CancellationToken cancel);
    Task<OrderDto> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancel);
    Task<bool> CancelOrderAsync(Guid orderId, CancellationToken cancel);
    Task<bool> ChangeOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancel);
}