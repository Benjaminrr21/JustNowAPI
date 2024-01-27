using JustNowBackend.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JustNowBackend.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int PIB { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WorkingTime { get; set; }
        public string? Slogan { get; set; }
        public string About { get; set; }

        public bool Status { get; set; }
        public List<Product> Products { get; set; }

        [JsonIgnore]
        public List<UserRestaurantGrades>  Grades { get; set; }
        public List<Order> Orders { get; set; }


        [ForeignKey(nameof(OwnerRestaurant))]
        public int OwnerId { get; set; }  
        [JsonIgnore]
  
        public OwnerRestaurant OwnerRestaurant { get; set; }

    }
}
