﻿namespace JustNowBackend.Data.Models
{
    public class UserRestaurantGrades
    {
        //public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int Grade { get; set; }
    }
}
