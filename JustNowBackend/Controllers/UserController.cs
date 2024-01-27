using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsers());
        }
        [HttpGet("/GetUserWithId/{id}")]
        public async Task<IActionResult> GetUserWithId([FromRoute]int id)
        {
            var obj = await userService.GetUserById(id);
            if(obj == null) { return NotFound("Korisnik sa ovim ID-em nije pronadjen u bazi."); }
            return Ok(obj);
        }
        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser([FromBody]UserRequestDTO user)
        {
            var u = mapper.Map<User>(user);
            await userService.AddUser(u);
            return Ok(u);
        }
        [HttpDelete("/DeleteUserWithId/{id}")]
        public async Task<IActionResult> DeleteUserWithId([FromRoute]int id)
        {
            var obj = await userService.DeleteUser(id);
            if(obj == null) { return NotFound("Ne moze se izbrisati nepostojeci korisnik."); }
            return Ok(obj);
        }
        [HttpPost("/RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody]UserRequestDTO user)
        {
            var obj = await userService.GetUserByUsername(user.Username);
            if(obj is not null)
            {
                return BadRequest("Korisnik je prijavljen.");
            }
            var userr = mapper.Map<User>(user);
            await userService.RegisterUser(userr);

            userr.Password = userService.HashPassword(user.Password);
            await userService.CreateRole(new UserRole
            {
                Name = "Prijavljeni korisnik",
                UserId = userr.Id
            });

            var token = userService.GenerateToken(userr);
            return Ok(new AuthResponseDTO
            {
                User = mapper.Map<UserResponseDTO>(userr),
                Token = token,
                Role = await userService.GetRole(userr.Username)

            });

        }
        [HttpPost("/LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO user)
        {
            var userLogin = await userService.GetUserByUsername(user.Username);
            if (userLogin == null)
            {
                return NotFound("Korisnik nije registrovan na aplikaciju.");
            }


            if (userService.HashPassword(user.Password) != userLogin.Password)
            {
                return BadRequest("Pogresna lozinka.");
            }
            var token = userService.GenerateToken(userLogin);
            return Ok(new AuthResponseDTO
            {
                Token = token,
                User = mapper.Map<UserResponseDTO>(userLogin),
                Role = await userService.GetRole(userLogin.Username)
            }) ; 
        }
        [HttpGet("/GetRole/{un}")]
        public async Task<IActionResult> GetRoleOfUser([FromRoute]string un)
        {
            var s = await userService.GetRole(un);
            return Ok(s);
        }

    }
}
