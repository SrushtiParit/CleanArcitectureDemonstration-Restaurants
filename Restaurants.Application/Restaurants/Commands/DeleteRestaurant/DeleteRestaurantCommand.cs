

using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

    public class DeleteRestaurantCommand: IRequest<bool>
    {
        public DeleteRestaurantCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
}

