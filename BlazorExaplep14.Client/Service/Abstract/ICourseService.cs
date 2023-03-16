using BlazorExaplep14.Common;
using BlazorExaplep14.Models;

namespace BlazorExaplep14.Client.Service.Abstract
{
    public interface ICourseService
    {
        public Task<Result<IEnumerable<CourseDto>>> getAllCourse();
        public Task<Result<CourseDto>> getCourse(int courseId);
    }
}
