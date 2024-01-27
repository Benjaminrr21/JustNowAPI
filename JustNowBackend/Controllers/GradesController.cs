using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class GradesController:ControllerBase
    {
        private readonly IGradeService gradeService;
        private readonly IMapper mapper;

        public GradesController(IGradeService gradeService, IMapper mapper)
        {
            this.gradeService = gradeService;
            this.mapper = mapper;
        }
        [HttpPost("/AddNewGrade")]
        public async Task<IActionResult> AddGrade(GradeDTO grade)
        {
            var g = mapper.Map<UserRestaurantGrades>(grade);
            await gradeService.AddGrade(g);
            return Ok(g);
        }
        [HttpGet("/GetAllGrades")]
        public async Task<IActionResult> GetAllGrades()
        {
            return Ok(await gradeService.GetAllGrades());
        }

    }
}
