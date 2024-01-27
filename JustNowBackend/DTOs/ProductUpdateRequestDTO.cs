namespace JustNowBackend.DTOs
{
    public class ProductUpdateRequestDTO
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
