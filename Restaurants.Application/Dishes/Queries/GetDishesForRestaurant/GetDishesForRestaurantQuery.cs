using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
{
    public Guid RestaurantId { get; }

    public GetDishesForRestaurantQuery(Guid restaurantId)
    {
        RestaurantId = restaurantId;
    }
}
