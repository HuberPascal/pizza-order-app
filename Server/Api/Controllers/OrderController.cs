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

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancel)
    {
        var orderDto = await orderService.CreateOrderAsync(request, cancel);

        return Ok(orderDto);
    }

    [HttpPut("{orderId}/cancel")]
    public async Task<IActionResult> CancelOrder(Guid orderId, CancellationToken cancel)
    {
        var success = await orderService.CancelOrderAsync(orderId, cancel);
        
        if (!success)
            return NotFound("Order not found or cannot be cancelled");

        return NoContent();
    }
}