
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IRestaurantRepository restaurantRepository, IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<CreateDishCommand, Guid>
{
    public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating dish {DishName} for restaurant {RestaurantId}", request.Name, request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            logger.LogWarning("Restaurant with ID {RestaurantId} not found", request.RestaurantId);
            throw new KeyNotFoundException($"Restaurant with ID {request.RestaurantId} not found.");
        }

        var dish = mapper.Map<Dish>(request);
        return await dishesRepository.CreateDishAsync(dish);
    }
}

