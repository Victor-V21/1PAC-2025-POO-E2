using E1U2POO.API.Database;
using E1U2POO.API.Helpers;
using E1U2POO.API.Services;
using E1U2POO.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Database

builder.Services.AddDbContext<PlanillaDbContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Interfaces
builder.Services.AddTransient<IEmpleadosServices, EmpleadoServices>();
builder.Services.AddTransient<IPlanillaServices, PlanillaServices>();
builder.Services.AddTransient<IDetallePlanillaServices, DetallePlanillaServices>();

builder.Services.AddAutoMapper(typeof(AutoMappersProfiles));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
