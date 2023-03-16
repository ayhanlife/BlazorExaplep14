using BlazorExaplep14.Common;
using BlazorExaplep14.Models;

namespace BlazorExaplep14.Business.Contracts
{
    public interface ICourseRepository
    {
        public Task<Result<CourseDto>> CreateCourse(CourseDto courseDto);
        public Task<Result<CourseDto>> UpdateCourse(int courseId,CourseDto courseDto);
        public Task<Result<CourseDto>> UpdateCourseImage(int courseId, string imagePath);
        public Task<Result<CourseDto>> GetCourse(int courseId);
        public Task<Result<int>> DeleteCourse(int courseId);
        public Task<Result<IEnumerable<CourseDto>>> GetAllCourse();
    }
}
