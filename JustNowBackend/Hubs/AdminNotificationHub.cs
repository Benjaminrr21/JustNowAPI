
namespace JustNowBackend.Hubs
{
    using JustNowBackend.Data.Models;
    using Microsoft.AspNetCore.SignalR;
    using System.Security.Claims;
    using System.Threading.Tasks;
    public class AdminNotificationHub : Hub
    {
        private static Dictionary<string, string> userConnections = new Dictionary<string, string>();

        public async Task SendRestaurantAcceptedNotification(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveRestaurantAcceptedNotification", message);
        }
        public async Task AddOrderNotification(string userId,string ord)
        {
            await Clients.Client(userId).SendAsync("AddOrder", ord);
        }
        public string getConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            // Perform any necessary logic when a client connects
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Perform any necessary logic when a client disconnects
            await base.OnDisconnectedAsync(exception);
        }


         public async Task SendNotification( string message)
         {
            //await Clients.Group.SendAsync("ReceiveNotification", message);
         }

        /*     public override async Task OnConnectedAsync()
             {
                 // Log connection information
                 Console.WriteLine($"Client connected: {Context.ConnectionId}");

                 await base.OnConnectedAsync();
             }

             // ... (your existing code)

             public override async Task OnDisconnectedAsync(Exception exception)
             {
                 // Log disconnection information
                 Console.WriteLine($"Client disconnected: {Context.ConnectionId}");

                 await base.OnDisconnectedAsync(exception);
             }*/


    }
}
