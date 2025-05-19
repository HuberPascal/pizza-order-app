using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EF.Models;
using EF.Models.Models;
using Core.Transports.Orders;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Core.Profiles;

namespace Core.Components.Orders;

public class OrderService(
    IMapper mapper,
    IApplicationDbContext context
    ) : IOrderService
{
    public async Task<IEnumerable<OrderDto>> GetAllAsync(Guid employeeId, CancellationToken cancel)
    {
        var order = await context.Orders
            .Where(o => o.UserId == employeeId)
            .ToListAsync(cancel);
        
        return mapper.Map<IEnumerable<OrderDto>>(order);
    }

    public async Task<OrderDto> GetOrderAsync(Guid orderId, CancellationToken cancel)
    {
        var order = await context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId, cancel); 
        
        return mapper.Map<OrderDto>(order);
    }
}