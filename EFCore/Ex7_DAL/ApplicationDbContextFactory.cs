using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Ex7_DAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<CourseManager>
    {
        public CourseManager CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseManager>();
            optionsBuilder.UseSqlServer(CourseManager.ConnectionString);

            return new CourseManager(optionsBuilder.Options);
        }
    }
}