using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IMediator mediator) : ControllerBase  //IRestaurantsService restaurantsService
    {
        [HttpGet]
        //[ProducesResponseType(statusCode: 200, Type = typeof(IEnumerable<RestaurantDto>))]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            //var restaurants = await restaurantsService.GetAllRestaurants();
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] Guid Id)
        {
            //var restaurant = await restaurantsService.GetRestaurantById(Id);
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(Id));
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantCommand command)
        {
            Guid id = await mediator.Send(command);
            //Guid id = await restaurantsService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);   //here the client will the address of the newly created resource
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid Id)
        {
            //var restaurant = await restaurantsService.GetRestaurantById(Id);
            var isDelete = await mediator.Send(new DeleteRestaurantCommand(Id));
            if (isDelete)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant (UpdateRestaurantCommand command)
        {
            var isUpdate = await mediator.Send(command);
            if (isUpdate)
            {
                return Ok();
            }
            return NotFound();
        }
    }


}
