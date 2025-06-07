using Core.Transports.Pizzas;

namespace Core.Components.Pizzas;

public interface IPizzaService
{
    Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancel);
    Task<PizzaDto?> GetByIdAsync(Guid id);
    Task<PizzaDto> CreateAsync(PizzaRequest pizzaRequest, CancellationToken cancel);
    Task<PizzaDto?> UpdateAsync(Guid id, PizzaRequest pizzaRequest, CancellationToken cancel);
    Task DeleteAsync(Guid id, CancellationToken cancel);
}