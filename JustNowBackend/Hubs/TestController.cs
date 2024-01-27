using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using JustNowBackend.Hubs;
using System.Threading.Tasks;

namespace JustNowBackend.Hubs
{
    [ApiController]
    //[Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<AdminNotificationHub> _hubContext;

        public TestController(IHubContext<AdminNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("/sendTestMessage")]
        public async Task<IActionResult> SendTestMessage()
        {
            // Send a test message to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveBroadcast", "This is a test message from the server!");

            return Ok("Test message sent successfully");
        }
    }

}
