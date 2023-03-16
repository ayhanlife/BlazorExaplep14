using AutoMapper;
using BlazorExaplep14.Business.Contracts;
using BlazorExaplep14.Common;
using BlazorExaplep14.DataAccess.Data;
using BlazorExaplep14.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExaplep14.Business.Implemetaion
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CourseDto>> CreateCourse(CourseDto courseDto)
        {
            try
            {
                var course = _mapper.Map<CourseDto, Course>(courseDto);
                course.CreatedBy = "Ayhan YILDIZ";
                var addedCourse = await _context.Course.AddAsync(course);
                await _context.SaveChangesAsync();
                var returnData = _mapper.Map<Course, CourseDto>(addedCourse.Entity);
                return new Result<CourseDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
            }
            catch (Exception ex)
            {
                string abc = ex.Message;
                return new Result<CourseDto>(false, ResultConstant.RecordCreateSuccessfully);
            }

        }

        public async Task<Result<int>> DeleteCourse(int courseId)
        {
            var courseDetails = await _context.Course.FindAsync(courseId);
            if (courseDetails != null)
            {
                _context.Course.Remove(courseDetails);
                var result = await _context.SaveChangesAsync();
                return new Result<int>(true, ResultConstant.RecordRemoveSuccessfully, result);
            }
            return new Result<int>(false, ResultConstant.RecordRemoveNotSuccessfully);
        }
        public async Task<Result<IEnumerable<CourseDto>>> GetAllCourse()
        {
            try
            {
                var courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_context.Course);
                return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courseDtos, courseDtos.ToList().Count);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<CourseDto>>(false, ResultConstant.RecordFound);
            }
        }

        public async Task<Result<CourseDto>> GetCourse(int courseId)
        {
            try
            {
                var data = await _context.Course.FirstOrDefaultAsync(x => x.Id == courseId);
                var returnData = _mapper.Map<Course, CourseDto>(data);
                return new Result<CourseDto>(true, ResultConstant.RecordFound, returnData);
            }
            catch (Exception ex)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordFound);
            }
        }

        public async Task<Result<CourseDto>> UpdateCourse(int courseId, CourseDto courseDto)
        {
            try
            {
                if (courseId == courseDto.Id)
                {
                    var courseDetails = await _context.Course.FindAsync(courseId);
                    var course = _mapper.Map<CourseDto, Course>(courseDto, courseDetails);
                    course.UpdatedBy = "Ayhan YILDIZ";
                    course.UpdatedDate = DateTime.Now;
                    var updateCourse = _context.Course.Update(course);
                    await _context.SaveChangesAsync();
                    var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                    return new Result<CourseDto>(true, ResultConstant.RecordUpdateSuccessfully, returnData);
                }
                else
                {
                    return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
                }
            }
            catch (Exception)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
        }

        public async Task<Result<CourseDto>> UpdateCourseImage(int courseId, string imagePath)
        {
            try
            {
                if (courseId > 0)
                {
                    var courseDetails = await _context.Course.FindAsync(courseId);
                    courseDetails.UpdatedBy = "Ayhan YILDIZ";
                    courseDetails.UpdatedDate = DateTime.Now;
                    courseDetails.ImageUrl = imagePath;
                    var updateCourse = _context.Course.Update(courseDetails);
                    await _context.SaveChangesAsync();
                    var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                    return new Result<CourseDto>(true, ResultConstant.RecordUpdateSuccessfully, returnData);
                }
                else
                {
                    return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
                }
            }
            catch (Exception)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
        }
    }
}
