﻿namespace JustNowBackend.Data.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public int? OwnerRestaurantId { get; set; }


    }
}