using Core.Components.Orders;
using EF.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Components.Orders;
using Core.Transports.Orders;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]

public class OrderController(
    ApplicationDbContext context,
    IOrderService orderService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<OrderDto>> Get(Guid employeeId, CancellationToken cancel)
    {
        return await orderService.GetAllAsync(employeeId, cancel);
    }

    [HttpGet]
    public async Task<OrderDto> GetById(Guid orderId, CancellationToken cancel)
    {
        return await orderService.GetOrderAsync(orderId, cancel);
    }
    
}