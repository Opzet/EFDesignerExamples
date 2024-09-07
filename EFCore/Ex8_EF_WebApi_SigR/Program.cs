using System.Diagnostics;
using Ex8_DAL_Multiuser;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DbContextOptionsBuilder<EFToDo> optionsBuilder;
optionsBuilder = new DbContextOptionsBuilder<EFToDo>();
optionsBuilder.UseSqlServer(EFToDo.ConnectionString);

//Spin up Database
if (Debugger.IsAttached)
{
    using (EFToDo db = new EFToDo())
    {
        db.Database.EnsureDeleted();
        Debug.WriteLine("Deleted DB\r\n");

        db.Database.EnsureCreated();
        Debug.WriteLine("Created DB\r\n");
    }

    //SeedData();
}

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
