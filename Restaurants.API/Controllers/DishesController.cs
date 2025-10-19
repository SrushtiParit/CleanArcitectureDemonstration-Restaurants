using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish(
        Guid restaurantId,
        [FromBody] CreateDishCommand command,
        CancellationToken cancellationToken)
    {       
        await mediator.Send(command, cancellationToken);
        return Created();
    }
}

