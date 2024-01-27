using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using JustNowBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class OwnerController:ControllerBase
    {
        private readonly IOwnerService ownerService;
        private readonly IMapper mapper;
        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            this.ownerService = ownerService;
            this.mapper = mapper;
        }
        [HttpPost("/AddOwner")]
        public async Task<IActionResult> AddOwner([FromBody]OwnerRestaurantRequestDTO rest)
        {
            var obj = mapper.Map<OwnerRestaurant>(rest);
            await ownerService.AddOwner(obj);
            return Ok(obj);
        }
        [HttpGet("/GetAllOwners")]
        public async Task<IActionResult> GetAllOwners()
        {
            var list = await ownerService.GetOwners();
            return Ok(list);
        }
        [HttpPost("/RegisterOwner")]
        public async Task<IActionResult> RegisterOwner([FromBody]OwnerRestaurantRequestDTO owner)
        {
            var o = mapper.Map<OwnerRestaurant>(owner);
            await ownerService.RegisterOwner(o);

            o.Password = ownerService.HashPassword(o.Password);
            await ownerService.CreateRole(new UserRole
            {
                Name = "Vlasnik restorana",
                OwnerRestaurantId = o.Id,
            });
            var token = ownerService.GenerateToken(o);
            return Ok(new AuthOwnerResponseDTO
            {
                Owner = o,
                Token = token,
             //   Role = 

            });


        }
        [HttpGet("/GetOwnerById/{id}")]
        public async Task<IActionResult> GetOwnerById([FromRoute] int id)
        {
            var obj = await ownerService.GetOwnerById(id);
            if (obj == null)
            {
                return NotFound("Objekat nije pronadjen u bazi.");
            }
            return Ok(obj);
        }
        [HttpPost("/LoginOwner")]
        public async Task<IActionResult> LoginOwner([FromBody] LoginOwnerDTO user)
        {
            var userLogin = await ownerService.GetOwnerByUsername(user.Username);
            if (userLogin == null)
            {
                return NotFound("Korisnik nije registrovan na aplikaciju.");
            }


            if (ownerService.HashPassword(user.Password) != userLogin.Password)
            {
                return BadRequest("Pogresna lozinka.");
            }
         

            var token = ownerService.GenerateToken(userLogin);
            return Ok(new AuthOwnerResponseDTO
            {
                Owner = userLogin,
                Token = token,

            });
        }
        [HttpGet("/getbool/{id}/{name}")]
        public async Task<IActionResult> gett([FromRoute]int id, [FromRoute]string name)
        {
            if(ownerService.IsThisRestaurantOfOwner(id,name) == null)
            {
                return BadRequest("Ovo nije vas restoran.");
            }
            return Ok("Uspesno...");
        }
    }
}
