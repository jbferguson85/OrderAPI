using System;
using AutoMapper;
using OrderAccessors.Entities;
using OrderCore.DTOs;

namespace OrderAccessors.MappingProfiles
{
    public class CustomerEntityProfile : Profile
    {
        public CustomerEntityProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
        }
    }
}
