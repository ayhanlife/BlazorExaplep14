using AutoMapper;
using BlazorExaplep14.DataAccess.Data;
using BlazorExaplep14.Models;

namespace BlazorExaplep14.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap().ForMember(c => c.ImageUrl, o => o.MapFrom<CourseItemUrlResolver>());
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
