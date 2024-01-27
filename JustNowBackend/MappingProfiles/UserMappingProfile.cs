using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestDTO, User>();
            CreateMap<User,UserResponseDTO>();
            //CreateMap<LoginUserDTO, UserResponseDTO>();
        }
    }
}
