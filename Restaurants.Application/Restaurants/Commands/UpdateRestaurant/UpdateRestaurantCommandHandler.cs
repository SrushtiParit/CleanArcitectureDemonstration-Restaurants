
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating the existing restaurant with Id: {Id}", request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant== null)
        {
            logger.LogInformation("Their the no record in the database with the {Id} Id", request.Id);
            return false;
        }
        mapper.Map(request, restaurant);
        await restaurantRepository.UpdateRestaurantAsync(restaurant);
        return true;
    }
}

