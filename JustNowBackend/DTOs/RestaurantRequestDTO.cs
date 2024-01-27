namespace JustNowBackend.DTOs
{
    public class RestaurantRequestDTO
    {
        public int PIB { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WorkingTime { get; set; }
        public string Slogan { get; set; }
        public int OwnerId { get; set; }
        public string About { get; set; }
        public bool Status { get; set; }

    }
}
