using AutoMapper;
using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JustNowBackend.Services
{
    public class UserService : IUserService
    {
        private readonly MyDBContext dBContext;
        //private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public UserService(MyDBContext dBContext, IMapper mapper, IConfiguration configuration)
        {
            this.dBContext = dBContext;
            _configuration = configuration; //mora se injectovatii
            //   this.mapper = mapper;
        }
        public async Task AddUser(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) {
                dBContext.Users.Remove(user);
                await dBContext.SaveChangesAsync();
            }
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dBContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Auth:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", user.Id.ToString()),
                    new Claim("Role", "Prijavljeni korisnik")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
        public string HashPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return String.Empty;
            }

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
        public async Task AddUserToRole(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
        }

        public async Task RegisterUser(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
        }

        public async Task CreateRole(UserRole role)
        {
            await dBContext.UserRoles.AddAsync(role);
            await dBContext.SaveChangesAsync();
        }
        public async Task<User?> GetUserByUsername(string username)
        {
            return await dBContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            
        }
        public async Task LoginUser(User user)
        {

        }

        public async Task<UserRole?> GetRole(string username)
        {
            var user = await GetUserByUsername(username);
            var role = await dBContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);

            return role;


            //RESTORANI 
        }


    }
}
