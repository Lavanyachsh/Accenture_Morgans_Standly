using Accenture_Morgans_Standly.hotelmanagement_DBModel;
using Accenture_Morgans_Standly.Interfaces;
using Accenture_Morgans_Standly.Repositores;
using Accenture_Morgans_Standly.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INewBookingRepository, NewBookingRepository>();
builder.Services.AddScoped<INewBookingServices, NewBookingServices>();
builder.Services.AddDbContext<HotelmanagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
//builder.Services.AddDbContext<HotelmanagementContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
