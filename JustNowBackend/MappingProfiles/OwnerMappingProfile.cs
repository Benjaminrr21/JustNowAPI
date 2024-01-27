using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile(){
            CreateMap<OwnerRestaurantRequestDTO, OwnerRestaurant>();
            CreateMap<OwnerRestaurant, UserResponseDTO>();  
        }


    }
}
