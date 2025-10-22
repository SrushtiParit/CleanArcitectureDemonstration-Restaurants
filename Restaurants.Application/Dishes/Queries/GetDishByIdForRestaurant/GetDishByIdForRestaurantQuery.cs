
using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(Guid restaurantId, Guid dishId) : IRequest<DishDto>
{
    public Guid RestaurantId { get; } = restaurantId;
    public Guid DishId { get; } = dishId;
}
