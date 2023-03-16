using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorExaplep14.DataAccess.Data
{
    public class CourseContext : IdentityDbContext
    {

        public CourseContext(DbContextOptions<CourseContext> options)
        : base(options)
        {
        }
        public DbSet<Course> Course { get; set; }
    }
}
