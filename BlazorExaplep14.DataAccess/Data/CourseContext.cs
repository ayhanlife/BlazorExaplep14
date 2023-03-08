using Microsoft.EntityFrameworkCore;

namespace BlazorExaplep14.DataAccess.Data
{
    public class CourseContext : DbContext
    {

        public CourseContext(DbContextOptions<CourseContext> options)
        : base(options)
        {
        }
        public DbSet<Course> Course { get; set; }
    }
}
