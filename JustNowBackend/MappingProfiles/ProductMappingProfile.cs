using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;

namespace JustNowBackend.MappingProfiles
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<ProductUpdateRequestDTO, Product>();
           // CreateMap<List<Product>, List<ProductResponseDTO>>();
        }
    }
}
