
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating the existing restaurant with Id: {Id} with {@updateRestaurant}", request.Id, request);    //@updateRestaurant is serialized object
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant== null)
        {
            //logger.LogInformation("Their the no record in the database with the {Id} Id", request.Id);
            //return false;
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }
        mapper.Map(request, restaurant);
        await restaurantRepository.UpdateRestaurantAsync(restaurant);
    }
}

