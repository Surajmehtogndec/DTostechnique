using Microsoft.EntityFrameworkCore;
using WebApi001.Data;
using WebApi001.Exceptions;
using WebApi001.Mappings;
using WebApi001.Repositories;
using WebApi001.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
MapsterConfig.RegisterMappings();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IBookRepository, BookRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


// Add services to the container.
builder.Services.AddDbContext<LibrarydbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),

        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )


    )

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();

app.Run();
