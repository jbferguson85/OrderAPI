using System;
using AutoMapper;
using OrderCore.Entities;
using OrderCore.DTOs;

namespace OrderCore.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>()
                .ReverseMap();
        }
    }
}