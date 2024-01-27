namespace JustNowBackend.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserRestaurantGrades>  Grades { get; set; }
        public List<UserRole> Roles { get; set; }
        public List<Order> Orders { get; set; }



    }
}
