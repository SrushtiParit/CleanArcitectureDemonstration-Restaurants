using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeder
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurantId = Guid.NewGuid(); // keep same Id for restaurant + dishes

            return new List<Restaurant>
            {
                new Restaurant
                {
                    Id = restaurantId,
                    RestaurantName = "The Spice Route",
                    Category = "Indian", // ✅ FIX: Category must be set
                    Description = "Authentic Indian flavors with a modern twist.",
                    HasDelivery = true,
                    ContactNumber = "123-456-7890",
                    ContactEmail = "info@spiceroute.com",
                    Address = new Address
                    {
                        Street = "123 Curry Lane",
                        City = "Flavor Town",
                        PostalCode = "12345"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Id = Guid.NewGuid(),
                            Name = "Butter Chicken",
                            Description = "Creamy and rich butter chicken with aromatic spices.",
                            Price = 12.99m,
                            RestaurantId = restaurantId // ✅ FIX: use parent restaurant's Id
                        },
                        new Dish
                        {
                            Id = Guid.NewGuid(),
                            Name = "Paneer Tikka",
                            Description = "Grilled paneer marinated in spices and served with mint chutney.",
                            Price = 8.99m,
                            RestaurantId = restaurantId // ✅ FIX: use parent restaurant's Id
                        }
                    }
                }
            };
        }

    }
}
