using System;
using AutoMapper;
using OrderAccessors.Entities;
using OrderCore.DTOs;

namespace OrderAccessors.MappingProfiles
{
    public class ProductEntityProfile : Profile
    {
        public ProductEntityProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}
