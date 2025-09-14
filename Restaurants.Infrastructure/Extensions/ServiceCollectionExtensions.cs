using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeder;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your infrastructure services here
            // For example:
            // services.AddScoped<IYourService, YourService>();
            // services.AddDbContext<YourDbContext>(options => options.UseSqlServer("YourConnectionString"));
            var connectionString = configuration.GetConnectionString("RestaurantsDev");
            services.AddDbContext<RestaurantsDbContext>(options=> options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            // Example of adding a singleton service
            // services.AddSingleton<ISomeSingletonService, SomeSingletonService>();

            // Example of adding a transient service
            // services.AddTransient<ISomeTransientService, SomeTransientService>();
        }
    }
}
