using AutoMapper;
using OrderCore.DTOs;
using OrderCore.Entities;

namespace OrderCore.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderEntity, OrderDto>().ReverseMap();
            CreateMap<OrderForCreationDto, OrderDto>()
                .AfterMap((s,d) => d.Customer = new CustomerDto{Id = s.CustomerId})
                .ReverseMap()
                .AfterMap((s, d) => d.CustomerId = s.Customer.Id);
            CreateMap<OrderForUpdateDto, OrderEntity>()
                .AfterMap((s, d) => d.Customer = new CustomerEntity {Id = s.CustomerId})
                .ReverseMap();
        }
    }
}