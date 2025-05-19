using Core.Transports.Orders;

namespace Core.Components.Orders;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync(Guid employeeId, CancellationToken cancel);
    Task<OrderDto> GetOrderAsync(Guid orderId, CancellationToken cancel);
}