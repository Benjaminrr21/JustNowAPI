namespace JustNowBackend.Data.Models
{
    public class Requests
    {
        public int Id { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public int RestPIB { get; set; }
        public string RestName { get; set; }
        public string Street { get; set; }
        public DateTime TimeSending { get; set; }
        public bool Statuss { get; set; }



    }
}
