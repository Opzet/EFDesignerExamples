// WebApi And Client

// Basic HTTP APIs Microservice on Server
// --------------------------------------
// At the simplest end, we now have basic HTTP APIs:
// you make a request to a URI, and it responds with data, hopefully in the format you requested (JSON, XML, etc.).
// This includes APIs that strictly conform with the ReST architectural style,
// but also simple “CRUD-over-HTTP” APIs that just use GET, PUT, POST and DELETE requests to retrieve, store and manage data.
// These APIs can apply security using any of the available HTTP authentication options,
// and can be made secure simply by applying SSL/TLS to the connection.
// For basic SOAP-over-HTTP or SOAP-over-TCP request/response WCF applications, an HTTP API is a good potential alternative.

// HTTP APIs created with .NET Core 2.x can be documented using Swagger,
// which includes the ability to read the API metadata from a known endpoint and generate client library code.

using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using Ex7_DAL;
using Microsoft.EntityFrameworkCore;

// -----------------------
//  Create WebApi
// -----------------------

var builder = WebApplication.CreateBuilder(args);

DbContextOptionsBuilder<CourseManager> optionsBuilder;
optionsBuilder = new DbContextOptionsBuilder<CourseManager>();
optionsBuilder.UseSqlServer(CourseManager.ConnectionString);

//Spin up Database
if (Debugger.IsAttached)
{
    using (CourseManager db = new CourseManager(optionsBuilder.Options))
    {
        //db.Database.EnsureDeleted();
        //Debug.WriteLine("Deleted DB\r\n");

        db.Database.EnsureCreated();
        Debug.WriteLine("Created DB\r\n");
    }

    //SeedData();
}

// Create WebApi
builder.Services.AddControllers();

// Register the CourseManager database context as a service
builder.Services.AddDbContext<CourseManager>(options =>
    options.UseSqlServer(CourseManager.ConnectionString)
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors());

//Creates Web Pages for dev
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// -------------------------- DATABASE UTILS ------------------------------------------
void SeedData()
{
    using (CourseManager db = new CourseManager(optionsBuilder.Options))
    {
        List<Student> students = new List<Student>
            {
            new Student{FirstName="Carson",LastName="Alexander" },//,EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Meredith",LastName="Alonso"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Arturo",LastName="Anand"},//EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Gytis",LastName="Barzdukas"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Yan",LastName="Li"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Peggy",LastName="Justice"},//EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Laura",LastName="Norman"},//EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Nino",LastName="Olivetto"}//EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

        foreach (Student s in students)
        {
            Student stu = new Student();
            stu.FirstName = s.FirstName;
            stu.LastName = s.LastName;

            db.Students.Add(stu);
        }

        db.SaveChanges();

        List<Course> courses = new List<Course>
            {
            new Course{CourseLabel="1050",Title="Chemistry",Credits=3,},
            new Course{CourseLabel="4022",Title="Microeconomics",Credits=3,},
            new Course{CourseLabel="4041",Title="Macroeconomics",Credits=3,},
            new Course{CourseLabel="1045",Title="Calculus",Credits=4,},
            new Course{CourseLabel="3141",Title="Trigonometry",Credits=4,},
            new Course{CourseLabel="2021",Title="Composition",Credits=3,},
            new Course{CourseLabel="2042",Title="Literature",Credits=4,}
            };

        foreach (Course c in courses)
        {
            Course course = new Course();
            course.CourseLabel = c.CourseLabel;
            course.Title = c.Title;
            course.Credits = c.Credits;

            db.Courses.Add(course);
        }

        db.SaveChanges();
    }

}

// -----------------------
//  Next Scaffold a controller
// -----------------------
//    Visual Studio
//    Right-click the Controllers folder.

//    Select Add > New Scaffolded Item.

//    Select API Controller with actions, using Entity Framework, and then select Add.

//    In the Add API Controller with actions, using Entity Framework dialog:

//    Select TodoItem(TodoApi.Models) in the Model class.
//    Select TodoContext(TodoApi.Models) in the Data context class.
//    Select Add.
//    If the scaffolding operation fails, select Add to try scaffolding a second time.
// -----------------------------------------------------------------------------------



#region  ardilo (https://www.fiverr.com/ardilo)

//    FIX: Expose the database context to the Visual Studion Design-time Tools
/*
 * 
//    Finding the generator 'controller'...
//    Running the generator 'controller'...
//    Minimal hosting scenario!
//    Attempting to figure out the EntityFramework metadata for the model and DbContext: 'Student'
//    Unable to create an object of type 'CourseManager'. For the different patterns supported at design time, 
//    see https://go.microsoft.com/fwlink/?linkid=851728 

//    StackTrace:Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions`1[Ex7_DAL.CourseManager]' while attempting to activate 'Ex7_DAL.CourseManager'.

// FIX: Add missing IDesignTimeDbContextFactory to Data Access Layer 

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
*/

#endregion

