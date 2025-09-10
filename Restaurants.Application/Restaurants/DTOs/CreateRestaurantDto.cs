using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.DTOs
{
    public class CreateRestaurantDto
    {
        //[StringLength(100, MinimumLength = 3)]    commented out validations are before/ without fluent validation implementation
        public string RestaurantName { get; set; } = default!;
        public string Description { get; set; } = default!;
        //[Required(ErrorMessage ="Insert a valid category")]
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
       // [Phone(ErrorMessage = "Insert a valid contact number")]
        public string? ContactNumber { get; set; }
       // [EmailAddress(ErrorMessage = "Insert a valid email address")]
        public string? ContactEmail { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
       // [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Insert a valid postal code in the format XX-XXX")]
        public string? PostalCode { get; set; }
    }
}
