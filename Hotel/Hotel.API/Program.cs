using Microsoft.EntityFrameworkCore;
using Hotel.Application.Contract;
using Hotel.Application.Services;
using Hotel.Infrastructure.Context;
using Hotel.IOC.Dependencies;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

builder.Services.AddEstadoHabitacionDependency();
builder.Services.AddHabitacionDependency();
// Add services to the container.


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
