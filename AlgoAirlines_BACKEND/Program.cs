using AlgoAirlines_BACKEND.AccesoDatos;
using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.AccesoDatos.Repositorios;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Helpers;
using AlgoAirlines_BACKEND.Middleware;
using AlgoAirlines_BACKEND.Servicios;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//builder.Services.AddMvc()
//              .AddJsonOptions(opt =>
//              {
//                  opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//              });

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
    ReferenceHandler.IgnoreCycles;
});


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080")
                               .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});



//REPOS
builder.Services.AddScoped<IRepositorio<Pasajero>, Repositorio<Pasajero>>();
builder.Services.AddScoped<IVueloRepositorio, VueloRepositorio>();
builder.Services.AddScoped<IRepositorio<Avion>, Repositorio<Avion>>();
builder.Services.AddScoped<IRepositorio<VueloPasajero>, Repositorio<VueloPasajero>>();
builder.Services.AddScoped<IRepositorio<Oficial>, Repositorio<Oficial>>();
builder.Services.AddScoped<IRepositorio<Ticket>, Repositorio<Ticket>>();
builder.Services.AddScoped<IRepositorio<Aeropuerto>, Repositorio<Aeropuerto>>();

//SERVICIOS
builder.Services.AddScoped<IAeropuertoServicio, AeropuertoServicio>();
builder.Services.AddScoped<IAvionServicio, AvionServicio>();
builder.Services.AddScoped<IVueloServicio, VueloServicio>();
builder.Services.AddScoped<IPasajeroServicio, PasajeroServicio>();
builder.Services.AddScoped<IOficialServicio, OficialServicio>();


builder.Services.AddScoped<IUnitOfWork, UnidadDeTrabajo>();

builder.Services.AddDbContext<ApplicationDbContext>(
       options => options.UseSqlServer("data source=DESKTOP-N128OIF\\SQLEXPRESS;initial catalog=Aerolinea;trusted_connection=true"));

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
