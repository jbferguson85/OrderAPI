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
            CreateMap<LineItemDto, LineItemForCreationDto>().ReverseMap();
            CreateMap<LineItemDto, LineItemForUpdateDto>().ReverseMap();
            CreateMap<LineItemForUpdateDto, LineItemEntity>().ReverseMap();
        }
    }
}