using JustNowBackend.Data.Models;

namespace JustNowBackend.DTOs
{
    public class RestaurantResponseDTO
    {
        public int Id { get; set; }
        public int PIB { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WorkingTime { get; set; }
        public string Slogan { get; set; }
       // public List<ProductResponseDTO> Products { get; set; }
    }
}
