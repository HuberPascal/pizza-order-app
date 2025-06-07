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

    [HttpPost]
    public async Task<ActionResult<PizzaDto>> Create(PizzaRequest pizzaRequest, CancellationToken cancel)
    {
        var createdPizza = await pizzaService.CreateAsync(pizzaRequest, cancel);

        return Ok(createdPizza);
    }

    [HttpPut]
    public async Task<ActionResult<PizzaDto>> Update(Guid id, PizzaRequest pizzaRequest, CancellationToken cancel)
    {
        var updatedPizza = await pizzaService.UpdateAsync(id, pizzaRequest, cancel);
        
        if (updatedPizza == null)
            return NotFound();

        return Ok(updatedPizza);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancel)
    {
        await pizzaService.DeleteAsync(id, cancel);
            
        return NoContent();
    }
}