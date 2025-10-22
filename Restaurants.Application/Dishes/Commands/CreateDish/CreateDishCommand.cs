using MediatR;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommand: IRequest<Guid>
{
    public Guid RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }
}

