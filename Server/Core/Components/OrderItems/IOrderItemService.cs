using Core.Transports.OrderItems;

namespace Core.Components.OrderItems;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAllAsync(Guid employeeId, CancellationToken cancel);
    Task<OrderItemDto> GetOrderItemAsync(Guid orderId, CancellationToken cancel);
}