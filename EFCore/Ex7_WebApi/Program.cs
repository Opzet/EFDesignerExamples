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

using System.Diagnostics;
using Ex7_DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Spin up Database
DbContextOptionsBuilder<CourseManager> optionsBuilder;
optionsBuilder = new DbContextOptionsBuilder<CourseManager>();
optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CourseManager;Trusted_Connection=True;MultipleActiveResultSets=true");
CourseManager courseManager = new CourseManager(optionsBuilder.Options);

if (Debugger.IsAttached)
{
    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.EnableSensitiveDataLogging();
    optionsBuilder.EnableDetailedErrors();
}
using (CourseManager db = new CourseManager(optionsBuilder.Options))
{

    db.Database.EnsureDeleted();
    Debug.WriteLine( "Deleted DB\r\n");

    db.Database.EnsureCreated();
    Debug.WriteLine("Created DB\r\n");

}

SeedData();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

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

        // If you get Duplicate Key added error, and it looks like PK is not auto incrementing but you have an Id setup ok..?
        // The issue arised because ef uses a Pk naming convention that sometimes contends with table field naming.
        // That is..Watch out for duplication / usage of both 'Id' and 'IdTablename' when creating db structure
        // as ef uses Pk naming convention and detection.  Think of it kind of like reserved keywords?

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