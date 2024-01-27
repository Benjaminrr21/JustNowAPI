using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class GradesMappingProfile:Profile
    {
        public GradesMappingProfile()
        {
            CreateMap<GradeDTO, UserRestaurantGrades>();
        }
    }
}
