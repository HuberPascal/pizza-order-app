using Microsoft.AspNetCore.Mvc;
using Core.Components.Pizzas;
using Core.Transports.Pizzas;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class PizzaController(
    IPizzaService pizzaService)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PizzaDto>>> GetAll(CancellationToken cancel)
    {
        var pizzas = await pizzaService.GetAllAsync(cancel);
        if (!pizzas.Any())
            return NoContent();

        return Ok(pizzas);
    }

    [HttpGet]
    public async Task<ActionResult<PizzaDto>> GetById(Guid id)
    {
        var pizza = await pizzaService.GetByIdAsync(id);
        
        if (pizza == null)
            return NotFound();
        
        return Ok(pizza);
    }
    
}