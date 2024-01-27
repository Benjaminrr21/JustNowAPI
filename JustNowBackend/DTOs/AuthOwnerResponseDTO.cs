using JustNowBackend.Data.Models;

namespace JustNowBackend.DTOs
{
    public class AuthOwnerResponseDTO
    {
        public OwnerRestaurant Owner { get; set; }
        public string Token { get; set; }
        //public UserRole Role { get; set; }
    }
}
