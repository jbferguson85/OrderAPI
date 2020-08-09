using AutoMapper;
using OrderAccessors.Entities;
using OrderCore.DTOs;

namespace OrderAccessors.MappingProfiles
{
    public class OrderEntityProfile : Profile
    {
        public OrderEntityProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}