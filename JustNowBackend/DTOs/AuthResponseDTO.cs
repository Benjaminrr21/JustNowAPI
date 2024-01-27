using JustNowBackend.Data.Models;

namespace JustNowBackend.DTOs
{
    public class AuthResponseDTO
    {
        public UserResponseDTO User { get; set; }
        public string Token { get; set; }
        public UserRole Role { get; set; }


    }
}
