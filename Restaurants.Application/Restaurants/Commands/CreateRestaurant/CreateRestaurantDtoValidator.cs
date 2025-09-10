
using FluentValidation;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantDtoValidator: AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["Indian", "Italian", "Chinese", "Mexican", "American", "Thai", "French", "Japanese", "Mediterranean", "Vegetarian", "Vegan"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(r => r.RestaurantName)
            .NotEmpty().WithMessage("Restaurant name is required.")
            .MaximumLength(100).WithMessage("Restaurant name cannot exceed 100 characters.");
        RuleFor(r => r.Category)
            .Must(category => validCategories.Contains(category))
            .WithMessage($"Category must be one of the following: {string.Join(", ", validCategories)}");
        //.Custom((value, context) =>
        //{
        //    var isValid = validCategories.Contains(value);
        //    if (!isValid)
        //    {
        //        context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", validCategories)}");
        //    }
        //});
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("Description is required.");
        RuleFor(r => r.ContactEmail)
            .EmailAddress().WithMessage("Insert a valid email address.");
        RuleFor(r => r.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Insert a valid postal code in the format XX-XXX. ");
    }
}

