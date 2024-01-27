using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using JustNowBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService requestsService;
        private readonly IMapper mapper;

        public RequestsController(IRequestsService requestsService, IMapper mapper)
        {
            this.requestsService = requestsService;
            this.mapper = mapper;
        }

        [HttpGet("/GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            var list = await requestsService.GetAllRequests();
            return Ok(list);
        }
        [HttpPost("/SendRequest")]
        public async Task<IActionResult> SendRequest([FromBody] RequestsRequestDTO r)
        {
            var req = mapper.Map<Requests>(r);
            await requestsService.SendRequest(req);
            return Ok(req);
        }
        [HttpDelete("/DeleteRequest/{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            //restaurantService.DeleteRestaurant(id);
            var obj = await requestsService.DeleteRequest(id);

            if (obj == null)
            {
                return NotFound("Ne moze se izbrisati nepostojeci objekat.");
            }
            //await restaurantService.DeleteRestaurant(id);
            return Ok(obj);
        }
        [HttpPut("/UpdateRequest/{id}")]
        public async Task<IActionResult> UpdateRequest([FromRoute]int id)
        {
            var obj = await requestsService.UpdateRequest(id);
            if(obj == null) { return NotFound("Nepostojeci request."); }
            return Ok(obj);
        }
    }
}
