using BusinessLayer;
using DataLayer;
using Microsoft.Extensions.Options;
using RestaurantAPI;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReservationLogic, ReservationLogic>();
builder.Services.AddScoped<IDataFactory, DataFactory>();
builder.Services.Configure<DataSettings>(builder.Configuration.GetSection("MySettings"));
builder.Services.AddLogging();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MyMiddleware>();

app.MapControllers();

app.Run();




