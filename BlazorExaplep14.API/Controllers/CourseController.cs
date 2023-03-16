using AutoMapper;
using BlazorExaplep14.Business.Contracts;
using BlazorExaplep14.Common;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExaplep14.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            var allCourse = await courseRepository.GetAllCourse();
            var data = allCourse;
            return Ok(data.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdCourse(int? courseId)
        {
            if (courseId is null)
            {
                return BadRequest(new Result<IActionResult>(false, ResultConstant.IdNotNull));
            }
            else
            {
                var course = await courseRepository.GetCourse((int)courseId);
                if (course != null)
                {
                    return Ok(course.Data);
                }
                else
                {
                    return BadRequest(new Result<IActionResult>(false, ResultConstant.IdNotNull));
                }
            }

        }
    }
}
