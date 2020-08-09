using AutoMapper;
using OrderAccessors.Entities;
using OrderCore.DTOs;

namespace OrderAccessors.MappingProfiles
{
    public class LineItemEntityProfile : Profile
    {
        public LineItemEntityProfile()
        {
            CreateMap<LineItemDto, LineItem>().ReverseMap();
        }
    }
}