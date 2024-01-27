using JustNowBackend.Data.Models;

namespace JustNowBackend.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task<User> DeleteUser(int id);
        Task<User> GetUserById(int id);
        string GenerateToken(User user);
        string HashPassword(string password);
        Task AddUserToRole(User user);

        Task RegisterUser(User user);
        Task CreateRole(UserRole role);
        Task<User?> GetUserByUsername(string username);
        Task<UserRole> GetRole(string username);

    }
}
