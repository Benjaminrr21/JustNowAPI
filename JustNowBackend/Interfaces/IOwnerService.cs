using JustNowBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Interfaces
{
    public interface IOwnerService
    {
        Task AddOwner(OwnerRestaurant owner);
        Task<List<OwnerRestaurant>> GetOwners();
        string GenerateToken(OwnerRestaurant owner);
        string HashPassword(string password);
        Task AddOwnerToRole(OwnerRestaurant owner);
        Task RegisterOwner(OwnerRestaurant owner);
        Task CreateRole(UserRole role);
        Task<OwnerRestaurant> GetOwnerById(int id);
        Task LoginOwner(OwnerRestaurant owner);
        Task <OwnerRestaurant> GetOwnerByUsername(string username);
        Task<UserRole> GetRole(string username);
        Task<List<Restaurant>> GetRestaurantsOfOwner(int id);
        Task<Restaurant> IsThisRestaurantOfOwner(int id,string rest);

    }
}
