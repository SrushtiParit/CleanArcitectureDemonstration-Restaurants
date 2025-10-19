

using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator: AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish=>dish.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(dish=>dish.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .When(dish=>dish.KiloCalories.HasValue)
            .WithMessage("KiloCalories must be greater than zero if provided.");
    }
}

