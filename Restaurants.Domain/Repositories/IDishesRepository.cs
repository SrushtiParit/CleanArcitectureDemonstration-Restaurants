
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<Guid> CreateDishAsync(Dish dish);
}

