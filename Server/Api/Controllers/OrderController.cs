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
    public async Task<OrderDto> Get(Guid employeeId, CancellationToken cancel)
    {
        return await orderService.GetAsync(employeeId, cancel);
    }
}