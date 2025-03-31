using Microsoft.EntityFrameworkCore;
using TourWebApi.Data;
using TourWebApi.Repositories;
using TourWebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Đăng ký Repository
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();


// Đăng ký Service
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();

// Cấu hình Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();
app.Run();
