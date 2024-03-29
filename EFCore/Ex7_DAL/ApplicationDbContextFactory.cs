﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Dynamic;

namespace Ex7_DAL
{

    // Some of the EF Core Tools commands(for example, the Scaffolding commands) require
    // a derived DbContext instance to be created at design time in order to gather details about the application's entity types
    // and how they map to a database schema. 

    // In most cases, it is desirable that the DbContext thereby created is configured in a similar way to how it would be configured at run time.
    /*
        The tools first try to obtain the service provider by invoking

        Program.CreateHostBuilder(),
        calling Build(),
        then accessing the Services property.

        Use a design-time factory, needs to be in DAL project (e.g Ex7_DAL), not in API project.
    */
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