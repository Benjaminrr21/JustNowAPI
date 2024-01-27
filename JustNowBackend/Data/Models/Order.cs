using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JustNowBackend.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }

        public bool Status { get; set; }


        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [JsonIgnore]

        public User User { get; set; }


    }
}
