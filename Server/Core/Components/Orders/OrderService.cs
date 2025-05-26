using EF.Models;
using EF.Models.Models;
using Core.Transports.Orders;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EF.Models.Enums;

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

    public async Task<OrderDto> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancel)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            DeliveryAddress = request.DeliveryAddress,
            CustomerNotes = request.CustomerNotes,
            PaymentMethod = request.PaymentMethod,
            OrderStatus = OrderStatus.Received,
            CreatedAt = DateTime.UtcNow,
            TotalPrice = 0,
            IsPaid = false,
            EstimatedDeliveryTime = DateTime.UtcNow.AddMinutes(30),
            OrderItems = new List<OrderItem>()
        };

        foreach (var itemRequest in request.OrderItems)
        {
            var pizza = await context.Pizzas.FindAsync(itemRequest.PizzaId);
            var extraToppings = await context.ExtraToppings
                .Where(et => itemRequest.ExtraToppingIds.Contains(et.Id))
                .ToListAsync(cancel);

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                PizzaId = pizza.Id,
                Quantity = itemRequest.Quantity,
                UnitPrice = pizza.Price,
                SpecialInstructions = itemRequest.SpecialInstructions,
                ExtraToppings = extraToppings
            };

            var extraToppingsPrice = extraToppings.Sum(et => et.Price);
            orderItem.TotalPrice = (orderItem.UnitPrice + extraToppingsPrice) * orderItem.Quantity;
            
            order.OrderItems.Add(orderItem);
        }

        order.TotalPrice = order.OrderItems.Sum(oi => oi.TotalPrice);
        
        await context.Orders.AddAsync(order, cancel);
        await context.SaveChangesAsync(cancel);
        
        return mapper.Map<OrderDto>(order);
    }

    public async Task<bool> CancelOrderAsync(Guid orderId, CancellationToken cancel)
    {
        var order = await context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId, cancel);

        if (order == null)
            return false;

        if (order.OrderStatus == OrderStatus.Delivered ||
            order.OrderStatus == OrderStatus.Cancelled)
            return false;

        if (order.OrderStatus != OrderStatus.Received &&
            order.OrderStatus != OrderStatus.Confirmed)
            return false;

        order.OrderStatus = OrderStatus.Cancelled;
        order.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancel);
        return true;
    }
}