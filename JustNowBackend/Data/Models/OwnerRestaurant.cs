using System.ComponentModel.DataAnnotations.Schema;

namespace JustNowBackend.Data.Models
{
    public class OwnerRestaurant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<UserRole> Roles { get; set; }
        public List<Restaurant> MyRestaurants { get; set; }
        //public List<Restaurant> Restaurants { get; set; }
    }
}
