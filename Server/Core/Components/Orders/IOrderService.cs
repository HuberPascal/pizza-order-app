namespace Core.Components.Orders;
using Core.Transports.Orders;

public interface IOrderService
{
    Task<OrderDto> GetAsync(Guid employeeId, CancellationToken cancel);
}