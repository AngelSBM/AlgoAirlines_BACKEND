using AlgoAirlines_BACKEND.AccesoDatos;
using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.AccesoDatos.Repositorios;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//REPOS
builder.Services.AddScoped<IRepositorio<Pasajero>, Repositorio<Pasajero>>();
builder.Services.AddScoped<IRepositorio<Vuelo>, Repositorio<Vuelo>>();
builder.Services.AddScoped<IRepositorio<Avion>, Repositorio<Avion>>();
builder.Services.AddScoped<IRepositorio<VueloPasajero>, Repositorio<VueloPasajero>>();
builder.Services.AddScoped<IRepositorio<Oficial>, Repositorio<Oficial>>();
builder.Services.AddScoped<IRepositorio<Aeropuerto>, Repositorio<Aeropuerto>>();

//SERVICIOS
builder.Services.AddScoped<IAeropuertoServicio, AeropuertoServicio>();
builder.Services.AddScoped<IAvionServicio, AvionServicio>();
builder.Services.AddScoped<IVueloServicio, VueloServicio>();
builder.Services.AddScoped<IPasajeroServicio, PasajeroServicio>();


builder.Services.AddScoped<IUnitOfWork, UnidadDeTrabajo>();

builder.Services.AddDbContext<ApplicationDbContext>(
       options => options.UseSqlServer("data source=DESKTOP-N128OIF\\SQLEXPRESS;initial catalog=Aerolinea;trusted_connection=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
