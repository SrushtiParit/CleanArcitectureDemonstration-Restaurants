using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

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
        command.RestaurantId = restaurantId;
        await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] Guid restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] Guid restaurantId, [FromRoute] Guid dishId)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] Guid restaurantId)
    {
        await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
        return NoContent();
    }
}

