

using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

    public class DeleteRestaurantCommand: IRequest
    {
        public DeleteRestaurantCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
}

