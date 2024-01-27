namespace JustNowBackend.DTOs
{
    public class OrderRequestDTO
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }


    }
}
