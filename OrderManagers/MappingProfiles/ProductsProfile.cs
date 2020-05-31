using System;
using AutoMapper;
using OrderCore.DTOs;
using OrderAccessors.Entities;

namespace OrderManagers.MappingProfiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
