using Database;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Api.Middlewares;
using SampleDotNet.API.InversionOfControl;
using SampleDotNet.Database.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddHttpContextAccessor();
//--------------------------- Add services to the container. ---------------------------//
DependencyContainer.RegisterServices(services);

//------------------------------ Token Settings ----------------------------------//
services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();

//--------------------------- Database - Mysql ------------------------------------//
var connectionString = builder.Configuration.GetConnectionString("Mysql");
services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
        .UseSnakeCaseNamingConvention()
        .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2)))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

//------------------------------ Database Redis ----------------------------------//
var redisConnectionString = builder.Configuration["RedisConnectionString"] ?? "localhost";
services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

var allowedHosts = builder.Configuration["AllowedHosts"];
//------------------------------ CORS ----------------------------------//
services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(allowedHosts ?? "*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//------------------------------ CORS ----------------------------------//
app.UseCors("corsapp");

app.UseHttpsRedirection();

//------------------------------ Middleware ----------------------------------//
app.UseRegisterMiddleware();
app.MapControllers();

app.Run();

