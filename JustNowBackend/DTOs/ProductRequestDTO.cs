using JustNowBackend.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustNowBackend.DTOs
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
