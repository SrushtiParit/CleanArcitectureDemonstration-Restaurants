
using MediatR;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery: IRequest<RestaurantDto>
{
    public GetRestaurantByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}

