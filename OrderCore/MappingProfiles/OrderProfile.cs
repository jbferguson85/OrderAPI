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
        }
    }
}