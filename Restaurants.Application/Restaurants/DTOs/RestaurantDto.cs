

using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs
{
    public class RestaurantDto
    {
        public Guid Id { get; set; }
        public string RestaurantName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; } = [];

        //public static RestaurantDto? fromEntity(Restaurant r)
        //{
        //    if (r == null)
        //    {
        //        return null;
        //    }
        //    return new RestaurantDto()
        //    {
        //        Category = r.Category,
        //        Description = r.Description,
        //        Id = r.Id,
        //        HasDelivery = r.HasDelivery,
        //        RestaurantName = r.RestaurantName,
        //        City = r.Address?.City,
        //        Street = r.Address?.Street,
        //        PostalCode = r.Address?.PostalCode,
        //        Dishes = r.Dishes.Select(DishDto.fromEntity).ToList()
        //    };
        //}
    }
}
