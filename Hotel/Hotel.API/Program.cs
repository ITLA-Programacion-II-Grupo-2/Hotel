using Microsoft.EntityFrameworkCore;
using Hotel.Infrastructure.Repositories;
using Hotel.Infrastructure.Context;
using System.Runtime.CompilerServices;
using Hotel.Infrastructure.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Registro de dependencia DBA.

builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

//Reposittories//
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();


//Registros de app services//

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
