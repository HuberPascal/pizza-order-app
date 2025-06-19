using Core.Components.ExtraToppings;
using Microsoft.AspNetCore.Mvc;
using Core.Components.Pizzas;
using Core.Transports.ExtraToppings;
using Core.Transports.Pizzas;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class ExtraToppingController(
    IExtraToppingService extraToppingService)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExtraToppingDto>>> GetAll(CancellationToken cancel)
    {
        var extraToppings = await extraToppingService.GetAllAsync(cancel);
        if (!extraToppings.Any())
            return NoContent();

        return Ok(extraToppings);
    }
}