using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with ID: {Id}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                //logger.LogWarning("Restaurant with ID: {Id} not found.", request.Id);
                //return false;
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            }
            await restaurantRepository.DeleteAsync(restaurant);
        }
    }
}
