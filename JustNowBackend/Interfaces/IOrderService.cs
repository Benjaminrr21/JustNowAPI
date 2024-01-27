using JustNowBackend.Data.Models;

namespace JustNowBackend.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersOfRestaurant(int id);
        Task <Order> AddNewOrder(Order order);
        Task <Order> TakeOrder(int id);
        Task <List<Order>> GetMyOrders(int userid);
        Task <Order> RemoveOrder(int id);
    }
}
