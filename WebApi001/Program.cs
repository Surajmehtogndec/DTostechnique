using Microsoft.EntityFrameworkCore;
using WebApi001.Data;
using Asp.Versioning;
using WebApi001.Exceptions;
using WebApi001.Mappings;
using WebApi001.Repositories;
using WebApi001.Repositories.Interfaces;
using WebApi001.Services;
using WebApi001.Services.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
MapsterConfig.RegisterMappings();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{ 
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "WebApi001 V1",
        Description = "WebApi001 V1"
    });

    options.SwaggerDoc(
        "v2", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Version = "v2",
            Title = "WebApi001 V2",
            Description = "WebApi001 V2"
        });
});

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


builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;

    options.ApiVersionReader = new MediaTypeApiVersionReader("v");
})
 .AddApiExplorer(options =>
 {
     options.GroupNameFormat = "'v'VVV";

     options.SubstituteApiVersionInUrl = true;
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    // 1. Custom endpoints ko development block ke andar hi rakhein
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi001 V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebApi001 V2");
    });
}
app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();

app.Run();
