using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with ID: {Id}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                logger.LogWarning("Restaurant with ID: {Id} not found.", request.Id);
                return false;
            }
            await restaurantRepository.DeleteAsync(restaurant);
            return true;
        }
    }
}
