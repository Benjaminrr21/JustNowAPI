using JustNowBackend.Data.Models;

namespace JustNowBackend.Interfaces
{
    public interface IRequestsService
    {
        Task SendRequest(Requests request);
        Task<List<Requests>> GetAllRequests();
        Task<Requests> DeleteRequest(int id);
        Task<Requests> UpdateRequest(int id);
    }
}
