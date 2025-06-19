using AutoMapper;
using Core.Transports.ExtraToppings;
using EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Components.ExtraToppings;

public class ExtraToppingService(
    IMapper mapper,
    IApplicationDbContext context
    ) : IExtraToppingService
{
    public async Task<IEnumerable<ExtraToppingDto>> GetAllAsync(CancellationToken cancel)
    {
        var extraToppings = await context.ExtraToppings
            .Where(et => et.IsAvailable)
            .ToListAsync(cancel);
        
        return mapper.Map<List<ExtraToppingDto>>(extraToppings);
    }
}