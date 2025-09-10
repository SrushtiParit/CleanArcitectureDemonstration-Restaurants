
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    Task<Restaurant?> IRestaurantRepository.GetByIdAsync(Guid id)
    {
        var restaurant = dbContext.Restaurants.Include(r=>r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
        //throw new NotImplementedException();
    }

    public async Task<Guid> Create(Restaurant entity)
    {
        dbContext.Restaurants.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task DeleteAsync(Restaurant restaurant)
    {
        dbContext.Remove(restaurant);
        return dbContext.SaveChangesAsync();
    }

    public Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        dbContext.Update(restaurant);
        return dbContext.SaveChangesAsync();
    }
}

