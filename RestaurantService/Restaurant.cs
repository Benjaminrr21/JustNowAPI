namespace RestaurantService
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
    }
}
