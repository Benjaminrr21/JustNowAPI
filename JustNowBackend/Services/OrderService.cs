using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.Hubs;
using JustNowBackend.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyDBContext context;
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> hubContext;

        public OrderService(MyDBContext context, Microsoft.AspNetCore.SignalR.IHubContext<AdminNotificationHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        public async Task<Order> AddNewOrder(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            string ord = $"Vasa narudzbina:\n{order.Name}\n{order.Amount}\n{order.OrderDate}\n{order.User}";
            await hubContext.Clients.All.SendAsync("NewOrderArrived", "Imate nove proudzbine!");
            return order;

        }

        public async Task<List<Order>> GetMyOrders(int userid)
        {
            return await context.Orders.Where(x => x.UserId == userid).ToListAsync();

        }

        public async Task<List<Order>> GetOrdersOfRestaurant(int id)
        {
            return await context.Orders.Where(x => x.RestaurantId == id).ToListAsync();
        }

        public async Task<Order> RemoveOrder(int id)
        {
            var obj = context.Orders.FirstOrDefault(x => x.Id == id);
            if (obj != null) context.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Order> TakeOrder(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if(order != null)
            {
                order.Status = true;
                context.Remove(order);
                await context.SaveChangesAsync();

                await hubContext.Clients.All
               .SendAsync("OrderDelivered", "Vasa proudzbina je primljena.");
            }
            return order;
        }
    }
}
