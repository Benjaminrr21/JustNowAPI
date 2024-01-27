using AutoMapper;
using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JustNowBackend.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly MyDBContext dBContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public OwnerService(MyDBContext dBContext, IMapper mapper, IConfiguration configuration)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task AddOwner(OwnerRestaurant owner)
        {
            await dBContext.Owners.AddAsync(owner);
            await dBContext.SaveChangesAsync();
        }

        public async Task<List<OwnerRestaurant>> GetOwners()
        {
            return await dBContext.Owners.ToListAsync();
        }

       
         public string GenerateToken(OwnerRestaurant owner)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration["Auth:Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", owner.Id.ToString()),
                    new Claim("Role", "Vlasnik restorana")
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
        public async Task AddOwnerToRole(OwnerRestaurant owner)
        {
            await dBContext.Owners.AddAsync(owner);
            await dBContext.SaveChangesAsync();
        }
        public async Task RegisterOwner(OwnerRestaurant owner)
        {
            await dBContext.Owners.AddAsync(owner);
            await dBContext.SaveChangesAsync();
        }

        public async Task CreateRole(UserRole role)
        {
            await dBContext.UserRoles.AddAsync(role);
            await dBContext.SaveChangesAsync();
        }

        public Task<OwnerRestaurant> GetOwnerById(int id)
        {
          
           var obj = dBContext.Owners.FirstOrDefaultAsync(x => x.Id == id);
           return obj;
            
        }

        public Task LoginOwner(OwnerRestaurant owner)
        {
            throw new NotImplementedException();
        }

        public async Task<OwnerRestaurant?> GetOwnerByUsername(string username)
        {
            return await dBContext.Owners.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }

        public async Task<UserRole> GetRole(string username)
        {
            var user = await GetOwnerByUsername(username);
            var role = await dBContext.UserRoles.FirstOrDefaultAsync(x => x.OwnerRestaurantId == user.Id);

            return role;
        }

        public async Task<List<Restaurant>> GetRestaurantsOfOwner(int id)
        {
            var list = dBContext.Restaurants.Where(x => x.OwnerId == id).ToList();
            return list;
        }

        public async Task<Restaurant?> IsThisRestaurantOfOwner(int id,string rest)
        {
            var obj = await dBContext.Restaurants.FirstOrDefaultAsync(x => x.Name == rest);
            if(obj != null && obj.OwnerId == id)
            {
                return obj;
            }
            return null;
            //return null;
            //return obj.MyRestaurants.FirstOrDefault(x => x.Name == rest);
        }
    }
    
}
