using AutoMapper;
using BlazorExaplep14.Common;
using BlazorExaplep14.DataAccess.Data;
using BlazorExaplep14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExaplep14.Business
{
    public class CourseItemUrlResolver : IValueResolver<Course, CourseDto, string>
    {
        public string Resolve(Course source, CourseDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
                return ResultConstant.ImageServerUrl + source.ImageUrl;
            return null;
        }
    }
}
