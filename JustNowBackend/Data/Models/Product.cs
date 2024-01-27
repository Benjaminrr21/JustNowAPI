using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JustNowBackend.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set;}
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        


    }
}
