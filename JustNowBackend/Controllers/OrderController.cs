using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Hubs;
using JustNowBackend.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService service;
        private readonly IMapper mapper;
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> _hubContext;
        public OrderController(IOrderService service, IMapper mapper, Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> hubContext)
        {
            this.service = service;
            this.mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet("/GetOrdersOfRestaurant/{id}")]
        public async Task<IActionResult> GetOrdersOfRestaurant([FromRoute] int id)
        {
            var list = await service.GetOrdersOfRestaurant(id);
            if(list.Count == 0)
            {
                return Ok("Nema novih porudzbina.");
            }

            return Ok(list);
        }

        [HttpPost("/AddNewOrder")]
        public async Task<IActionResult> AddNewOrder(OrderRequestDTO order)
        {
            var o = mapper.Map<Order>(order);
            await service.AddNewOrder(o);

            return Ok(o);
        }
        [HttpPut("/TakeOrder/{id}")]
        public async Task<IActionResult> TakeOrder([FromRoute]int id)
        {
            var o = await service.TakeOrder(id);
            if(o == null)
            {
                return NotFound("Nepostojeca porudzbina.");
            }
            return Ok(o);

        }
        [HttpGet("/GetMyOrders/{id}")]
        public async Task<IActionResult> GetMyOrders([FromRoute]int id)
        {
            var list = await service.GetMyOrders(id);
            if (list.Count == 0)
            {
                return Ok("Nema stavki na racunu.");
            }

            return Ok(list);
        }
        [HttpDelete("/RemoveOrder/{id}")]
        public async Task <IActionResult> RemoveOrder([FromRoute]int id)
        {
            var obj = await service.RemoveOrder(id);
            if(obj == null)
            {
                return NotFound("Nepostojeca porudzbina.");
            }
            return NoContent();
        }
    }
}
