
using MediatR;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

    public class UpdateRestaurantCommand: IRequest
    {
        public Guid Id { get; set; }
        public string RestaurantName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool hasDelivery { get; set; }
    }

