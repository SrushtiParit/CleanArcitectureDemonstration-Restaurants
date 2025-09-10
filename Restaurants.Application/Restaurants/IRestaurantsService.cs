using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        //Task<Guid> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto> GetRestaurantById(Guid id);
    }
}