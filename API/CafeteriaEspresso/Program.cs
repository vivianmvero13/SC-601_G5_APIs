using CafeteriaEspresso.Data;
using CafeteriaEspresso.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var _connectionStrings = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(_connectionStrings, ServerVersion.AutoDetect(_connectionStrings))
);

//Inclusion de servicios
//builder.Services.AddSingleton<FacturasService>();
//Inclusion de controladores
builder.Services.AddScoped<PaisService>();
builder.Services.AddScoped<ProvinciaService>();
builder.Services.AddScoped<CantonService>();
builder.Services.AddScoped<DistritoService>();
builder.Services.AddScoped<FacturasService>();
builder.Services.AddScoped<MetodoPagoService>();
builder.Services.AddScoped<ReservasService>();
builder.Services.AddScoped<PromocionesService>();
builder.Services.AddScoped<ResenasService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
