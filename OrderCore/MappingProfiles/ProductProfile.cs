using OrderCore.DTOs;
using OrderCore.Entities;
using AutoMapper;

namespace OrderCore.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>()
                .ReverseMap();
        }
    }
}