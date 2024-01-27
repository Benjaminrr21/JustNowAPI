using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Services
{
    public class RequestsService : IRequestsService
    {
       // private readonly IRequestsService _requestsService;
        private readonly MyDBContext context;


        public RequestsService(MyDBContext context)
        {
            
            this.context = context;
        }

        public async Task<Requests?> DeleteRequest(int id)
        {
           var obj = await context.Requests.FirstOrDefaultAsync(x => x.Id == id);
           if (obj != null)
            {
                context.Requests.Remove(obj);
            }
            await context.SaveChangesAsync();
            return obj;

        }

        public async Task<List<Requests>> GetAllRequests()
        {
            return await context.Requests.ToListAsync();
        }

        public async Task SendRequest(Requests request)
        {
            await context.Requests.AddAsync(request);
            await context.SaveChangesAsync();
        }

        public async Task<Requests?> UpdateRequest(int id)
        {
            var req = await context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            if (req != null)
            {
                req.Statuss = true;
                await context.SaveChangesAsync();

            }
            return req;



        }
    }
}
