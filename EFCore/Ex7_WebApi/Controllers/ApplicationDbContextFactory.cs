using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Ex7_DAL;

namespace Ex7_WebApi
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