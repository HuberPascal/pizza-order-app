using AutoMapper;
using EF.Models;
using Microsoft.EntityFrameworkCore;
using Core.Transports.Pizzas;
using EF.Models.Models;

namespace Core.Components.Pizzas;

public class PizzaService(
    IMapper mapper,
    IApplicationDbContext context
    ) : IPizzaService
{
    public async Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancel)
    {
        var pizzas = await context.Pizzas
            .Where(p => p.IsAvailable)
            .ToListAsync(cancel);
        
        return mapper.Map<List<PizzaDto>>(pizzas);
    }

    public async Task<PizzaDto?> GetByIdAsync(Guid id)
    {
        var pizza = await context.Pizzas.FindAsync(id);
        
        if (pizza == null) 
            return null;
        
        return mapper.Map<PizzaDto>(pizza);
    }

    public async Task<PizzaDto> CreateAsync(PizzaRequest pizzaRequest, CancellationToken cancel)
    {
        var pizza = new Pizza
        {
            Id = Guid.NewGuid(),
            Name = pizzaRequest.Name,
            Description = pizzaRequest.Description,
            Price = pizzaRequest.Price,
            ImageUrl = pizzaRequest.ImageUrl,
            IsVegetarian = pizzaRequest.IsVegetarian,
            IsVegan = pizzaRequest.IsVegan,
            IsAvailable = pizzaRequest.IsAvailable,
            BaseIngredients = pizzaRequest.BaseIngredients,
        };
            
        await context.Pizzas.AddAsync(pizza, cancel);
        await context.SaveChangesAsync(cancel);
            
        return mapper.Map<PizzaDto>(pizza);
    }

    public async Task<PizzaDto?> UpdateAsync(Guid id, PizzaRequest pizzaRequest, CancellationToken cancel)
    {
        var pizza = await context.Pizzas
            .FirstOrDefaultAsync(p => p.Id == id, cancel);
        
        if (pizza == null) 
            return null;
        
        pizza.Name = pizzaRequest.Name;
        pizza.Description = pizzaRequest.Description;
        pizza.Price = pizzaRequest.Price;
        pizza.ImageUrl = pizzaRequest.ImageUrl;
        pizza.IsVegetarian = pizzaRequest.IsVegetarian;
        pizza.IsVegan = pizzaRequest.IsVegan;
        pizza.IsAvailable = pizzaRequest.IsAvailable;
        pizza.BaseIngredients = pizzaRequest.BaseIngredients;
        
        await context.SaveChangesAsync(cancel);

        return mapper.Map<PizzaDto>(pizza);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancel)
    {
        var pizza = await context.Pizzas.FindAsync(id);
        
        if (pizza == null)
            return;
        
        pizza.IsAvailable = false; // Soft Delete
        
        // context.Pizzas.Remove(pizza); Hard Delete
        await context.SaveChangesAsync(cancel);
    }
}