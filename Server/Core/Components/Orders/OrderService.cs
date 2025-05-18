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
    public async Task<OrderDto> GetAsync(Guid employeeId, CancellationToken cancel)
    {
        var order = await context.Orders
            .Where(o => o.Id == employeeId)
            .FirstOrDefaultAsync(cancel);
        
        return mapper.Map<OrderDto>(order);
    }
}