using AutoMapper;
using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Hubs;
using JustNowBackend.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly MyDBContext dBContext;
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> hubContext;


        public RestaurantService(MyDBContext dBContext, Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> hubContext)
        {
            this.dBContext = dBContext;
            this.hubContext = hubContext;
        }
        public async Task AddRestaurant(Restaurant rest)
        {
            
            await dBContext.Restaurants.AddAsync(rest);
            await dBContext.SaveChangesAsync();
            await hubContext.Clients.All.SendAsync("ReceiveNotification", "Imate nove proudzbine!");
        }

        public async Task<Restaurant> DeleteRestaurant(int id)
        {
            var obj = dBContext.Restaurants.FirstOrDefault(x => x.Id == id);
            if(obj != null ) dBContext.Remove(obj);
            await dBContext.SaveChangesAsync();
            return obj;
        }

        public async Task<List<Restaurant>> FilterRestaurants(string pr)
        {
            //var lista = await dBContext.Restaurants.Include(r => r.Products).ToListAsync();
            var listaProducts = await dBContext.Products.Where(p => p.Name == pr).ToListAsync();
            var filterList = new List<Restaurant>();
            
                foreach (var product in listaProducts)
                {
                    var restaurant = await dBContext.Restaurants.FirstOrDefaultAsync(x => x.Id == product.RestaurantId);

                    if (restaurant != null)
                    {
                        filterList.Add(restaurant);
                    }
                }
            
            return filterList;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            var lista = await dBContext.Restaurants.Include(p => p.Products).ToListAsync();
            /*foreach(var obj in lista)
            {   
                obj.Products = await dBContext.Products.Where(p => p.RestaurantId == obj.Id).ToListAsync();
            }*/
            return lista;
            
        }

        public async Task<double> GetAverageGrade(int id)
        {
            var list = await dBContext.Grades.Where(x => x.RestaurantId == id).ToListAsync();
      
            return Math.Round(list.Average(x => x.Grade),2);
        }
        public async Task<List<Restaurant>> SortByGrade()
        {
            var lista =  await dBContext.Restaurants.Include(r => r.Grades).ToListAsync();

            var newList = lista
            .Where(r => r.Grades != null && r.Grades.Any())
            .OrderByDescending(r => r.Grades.Average(x => x.Grade))
            .ToList();

            return newList;
            
        }

        public async Task<string?> GetNameOfRestaurant(int id)
        {
            var obj = await dBContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            if(obj == null) return null;
            return obj.Name;
        }

        public Task<Restaurant> GetRestaurantById(int id)
        {
            var obj = dBContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }

        public async Task<List<Restaurant>> GetRestaurantsOfOwner(int id)
        {
            return await dBContext.Restaurants.Where(x => x.OwnerId == id).ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantsOnWaiting()
        {
            var lista = await dBContext.Restaurants.Where(x => x.Status == false).ToListAsync();
            return lista;
        }

        public async Task<List<Restaurant>> SearchRestaurantsByName(string name)
        {
            //if (string.IsNullOrEmpty(name) || dBContext == null)
            //{
            // Handle null or empty input, or null dbContext
            //  return new List<Restaurant>();
            //}

            var list = await dBContext.Restaurants
               .Where(r => r.Name.ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;
        }

       

        public async Task<Restaurant?> UpdateRestaurant(int id, Restaurant restaurant)
        {
            var rest = await dBContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            if(rest != null)
            {
                rest.Name = restaurant.Name;
                rest.PIB = restaurant.PIB;
                rest.Location = restaurant.Location;
                rest.WorkingTime = restaurant.WorkingTime;

                rest.Location = restaurant.Location;
                rest.Slogan = restaurant.Slogan;
                rest.About = restaurant.About;
                rest.UrlPhoto = restaurant.UrlPhoto;
            }
            await dBContext.SaveChangesAsync();
            return rest;
        }
        public async Task<Restaurant?> UpdateStatus(int id)
        {
            var req = await dBContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

            if (req != null)
            {
                req.Status = true;
                await dBContext.SaveChangesAsync();

                await hubContext.Clients.All
                .SendAsync("ReceiveNotification", "Vaš zahtev je prihvaćen. Unesite ostale podatke o vašem restoranu...");


            }
            return req;



        }
    }
}
