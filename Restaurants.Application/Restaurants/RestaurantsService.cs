using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using AutoMapper;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        throw new NotImplementedException();
    }

    //public async Task<Guid> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
    //{
    //    logger.LogInformation("Creating a new restaurant with name: ");
    //    var  restaurant = mapper.Map<Restaurant>(createRestaurantDto);
    //    Guid id = await restaurantRepository.Create(restaurant);
    //    return id;
    //}

    //public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    //{
    //    logger.LogInformation("Fetching all restaurants from the repository.");
    //    var restaurants = await restaurantRepository.GetAllAsync();

    //    // mapping the restaurant entities to DTOs
    //    //var restaurantDto = restaurants.Select(r => new RestaurantDto()
    //    //{
    //    //    Category = r.Category,
    //    //    Description = r.Description,
    //    //    Id = r.Id,
    //    //    HasDelivery = r.HasDelivery,
    //    //    RestaurantName = r.RestaurantName,
    //    //    City = r.Address?.City,
    //    //    Street = r.Address?.Street,
    //    //    PostalCode = r.Address?.PostalCode
    //    //});

    //    // mapping using the fromEntity method, using constructor in the dto class
    //    //var restaurantDto = restaurants.Select(RestaurantDto.fromEntity);

    //    var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
    //    return restaurantDto!;
    //}

    public async Task<RestaurantDto> GetRestaurantById(Guid id)
    {
                logger.LogInformation("Fetching restaurant with ID: {Id}", id);
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        //var restaurantDto = RestaurantDto.fromEntity(restaurant);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        if (restaurantDto == null)
        {
            logger.LogWarning("Restaurant with ID: {Id} not found.", id);
        }
        return restaurantDto!;
    }
}

