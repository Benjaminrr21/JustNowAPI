using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using JustNowBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net.WebSockets;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class RestaurantController:ControllerBase
    {
        private readonly IRestaurantService restaurantService;
        private readonly IMapper mapper;
        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            this.restaurantService = restaurantService;
            this.mapper = mapper;
        }

        [HttpGet("/GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var lista = await restaurantService.GetAllRestaurants();
            return Ok(lista);
        }
        [HttpPost("/AddRestaurant")]
        public async Task <IActionResult> AddRestaurant([FromBody]RestaurantRequestDTO rest)
        {
            var obj = mapper.Map<Restaurant>(rest);
            await restaurantService.AddRestaurant(obj);

            return Ok(obj);
        }
        [HttpGet("/GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute]int id)
        {
            var obj = await restaurantService.GetRestaurantById(id);
            if(obj == null)
            {
                return NotFound("Objekat nije pronadjen u bazi.");
            }
            return Ok(obj);
        }
        [HttpDelete("/DeleteRestaurant/{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
        {
            //restaurantService.DeleteRestaurant(id);
            var obj = await restaurantService.DeleteRestaurant(id);

            if (obj == null)
            {
                return NotFound("Ne moze se izbrisati nepostojeci objekat.");
            }
            //await restaurantService.DeleteRestaurant(id);
            return Ok(obj);
        }
        [HttpPut("/UpdateRestaurant/{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute]int id, [FromBody]RestaurantRequestDTO restaurant)
        {
            var obj = await restaurantService.UpdateRestaurant(id, mapper.Map<Restaurant>(restaurant));
            if(obj == null)
            {
                return NotFound("Objekat ne postoji u bazi.");
            }
            return Ok(obj);
        }
        [HttpGet("/SearchRestaurantByName/{name}")]
        public async Task<IActionResult> SearchRestaurantsByName([FromRoute]string name)
        {
            var lista = await restaurantService.SearchRestaurantsByName(name);
            if (lista.Count() == 0) return NotFound("Nema restorana koji se podudaraju sa vasom pretragom.");
            return Ok(lista);
            
        }
        [HttpGet("/GetNameOfRestaurant/{id}")]
        public async Task<IActionResult> GetNameOfRestaurant([FromRoute] int id)
        {
            var s = await restaurantService.GetNameOfRestaurant(id);
            if (s == null) return NotFound("Nije pronadjen restoran sa ovim Idem");
            return Ok(s);
        }
        [HttpGet("/GetRestaurantsOnWaiting")]
        public async Task<IActionResult> GetRestaurantsOnWaiting()
        {
            var l = await restaurantService.GetRestaurantsOnWaiting();
            return Ok(l);
            
        }
        [HttpPut("/UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id)
        {
            var obj = await restaurantService.UpdateStatus(id);
            if (obj == null) { return NotFound("Nepostojeci request."); }
            return Ok(obj);
        }
        [HttpGet("/GetRestaurantsOfOwner/{id}")]
        public async Task<IActionResult> GetRestaurantsOfOwner([FromRoute] int id)
        {
            return Ok(await restaurantService.GetRestaurantsOfOwner(id));
        }
        [HttpGet("/GetAverageGrade/{id}")]
        public async Task<IActionResult> GetAverageGrade([FromRoute] int id)
        {
            return Ok(await restaurantService.GetAverageGrade(id));
        }
        [HttpGet("/FilterRestaurantsByProduct/{name}")]
        public async Task<IActionResult> FilterRestaurantByProduct([FromRoute]string name)
        {
            return Ok(await restaurantService.FilterRestaurants(name));
        }
        [HttpGet("/SortRestaurants")]
        public async Task <IActionResult> SortRestaurants()
        {
            var list = await restaurantService.SortByGrade();
            return Ok(list);
        }
    }

}

