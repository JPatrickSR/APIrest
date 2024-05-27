using System.Diagnostics;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DS.DriveShare.Persistence.Repositories;
using DS.DriveShare.Domain.Repositories;
using DS.DriveShare.Domain.Services;
using DS.DriveShare.Services;
using DS.Share.Persistance.Contexts;
using DS.Share.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DriveShare API",
        Description = "DriveShare RESTful API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name="DriveShare Contact",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//ADD Database Connection MYSQL

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine,LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


//Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);


//shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Dependency Injection CONFIGURATION


builder.Services.AddScoped<IParkingRepository, ParkingRepository>();


builder.Services.AddScoped<IParkingService, ParkingServices>();


//AutoMapper Configuration



builder.Services.AddAutoMapper(

    typeof(DS.DriveShare.Mapping.ModelToResourceProfile),
    typeof(DS.DriveShare.Mapping.ResourceToModelProfile));

var app = builder.Build();

//Validation FOR ensuring Database Objects are created

using(var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
        
    });
}

// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();