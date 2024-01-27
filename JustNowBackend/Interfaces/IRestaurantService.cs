using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.Interfaces
{
    public interface IRestaurantService 
    {
        Task<List<Restaurant>> GetAllRestaurants();
        Task AddRestaurant(Restaurant rest);
        Task<Restaurant> DeleteRestaurant(int id);
        Task <Restaurant> GetRestaurantById(int id);
        Task <Restaurant> UpdateRestaurant(int id, Restaurant restaurant);
        Task <List<Restaurant>> SearchRestaurantsByName(string name);
        Task <string> GetNameOfRestaurant(int id);
        Task<List<Restaurant>> GetRestaurantsOnWaiting();
        public Task<Restaurant> UpdateStatus(int id);
        Task<List<Restaurant>> GetRestaurantsOfOwner(int id);
        Task <double> GetAverageGrade(int id);
        Task<List<Restaurant>> FilterRestaurants(string p);
        Task<List<Restaurant>> SortByGrade();
    }
}
