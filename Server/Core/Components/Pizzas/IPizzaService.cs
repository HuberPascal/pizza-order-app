using Core.Transports.Pizzas;

namespace Core.Components.Pizzas;

public interface IPizzaService
{
    Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancel);
    Task<PizzaDto> GetByIdAsync(Guid id);
}