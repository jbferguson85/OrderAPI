using AutoMapper;
using OrderCore.DTOs;
using OrderCore.Entities;

namespace OrderCore.MappingProfiles
{
    public class LineItemProfile : Profile
    {
        public LineItemProfile()
        {
            CreateMap<LineItemDto, LineItemEntity>().ReverseMap();
        }
    }
}