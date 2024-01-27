using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<RestaurantRequestDTO, Restaurant>();
            CreateMap<Restaurant,RestaurantResponseDTO>();
           // CreateMap<List<Restaurant>,List<RestaurantResponseDTO>>();
        }
    }
}
