using BlazorExaplep14.Client.Service.Abstract;
using BlazorExaplep14.Common;
using BlazorExaplep14.Models;
using Newtonsoft.Json;

namespace BlazorExaplep14.Client.Service.Contract
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<CourseDto>>> getAllCourse()
        {
            var response = await _httpClient.GetAsync("https://localhost:44316/api/course/getcourse");
            var content = await response.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseDto>>(content);
            return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courses);
        }

        public async Task<Result<CourseDto>> getCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
