using AutoMapper;
using BlazorExaplep14.DataAccess.Data;

namespace BlazorExaplep14.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
