using System;
using AutoMapper;
using OrderCore.DTOs;
using OrderData.Entities;

namespace OrderManagers.MappingProfiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(s => s.Price, opt => opt.Ignore())
                .AfterMap((s, d) => d.Price = s.Price.ProductPrice);
        }
    }
}
