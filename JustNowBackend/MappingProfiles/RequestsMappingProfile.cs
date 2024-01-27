using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class RequestsMappingProfile:Profile
    {
        public RequestsMappingProfile()
        {
            CreateMap<RequestsRequestDTO,Requests>();
        }
    }
}
