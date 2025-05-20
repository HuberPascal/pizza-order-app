using EF.Models;
using Core.Transports.OrderItems;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Core.Components.OrderItems;

public class OrderItemService(
    IMapper mapper,
    IApplicationDbContext context
) : IOrderItemService
{
    public async Task<IEnumerable<OrderItemDto>> GetAllAsync(Guid employeeId, CancellationToken cancel)
    {
        var order = await context.Orders
            .Where(o => o.UserId == employeeId)
            .ToListAsync(cancel);
        
        return mapper.Map<IEnumerable<OrderItemDto>>(order);
    }

    public async Task<OrderItemDto> GetOrderItemAsync(Guid orderId, CancellationToken cancel)
    {
        var order = await context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId, cancel); 
        
        return mapper.Map<OrderItemDto>(order);
    }
}