using Core.Transports.ExtraToppings;

namespace Core.Components.ExtraToppings;

public interface IExtraToppingService
{
    Task<IEnumerable<ExtraToppingDto>> GetAllAsync(CancellationToken cancel);
}