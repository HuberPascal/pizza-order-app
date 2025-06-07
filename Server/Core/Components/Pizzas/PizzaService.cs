using AutoMapper;
using EF.Models;
using Microsoft.EntityFrameworkCore;
using Core.Transports.Pizzas;

namespace Core.Components.Pizzas;

public class PizzaService(
    IMapper mapper,
    IApplicationDbContext context
    ) : IPizzaService
{
    public async Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancel)
    {
        var pizzas = await context.Pizzas.ToListAsync(cancel);
        
        return mapper.Map<List<PizzaDto>>(pizzas);
    }

    public async Task<PizzaDto> GetByIdAsync(Guid id)
    {
        var pizza = await context.Pizzas.FindAsync(id);
        
        if (pizza == null) return null;
        
        return mapper.Map<PizzaDto>(pizza);
    }
}