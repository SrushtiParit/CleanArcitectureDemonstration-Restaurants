
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching restaurant with ID: {Id}", request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        //var restaurantDto = RestaurantDto.fromEntity(restaurant);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        if (restaurantDto == null)
        {
            logger.LogWarning("Restaurant with ID: {Id} not found.", request.Id);
        }
        return restaurantDto;
    }
}

