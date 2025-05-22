using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using api.Authentication;
using application.Services;
using domain.Interfaces;
using infraestructure.Data;
using infraestructure.Repositories;
using api.Authentication;
using application.Services;
using domain.Interfaces;
using infraestructure.Data;
using infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar autenticación con API Key
builder.Services.AddAuthentication("ApiKeyScheme")
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthHandler>("ApiKeyScheme", null);

builder.Services.AddAuthorization();

// Configuración de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); // ← necesario para que funcione la autenticación
app.UseAuthorization();

app.MapControllers();

app.Run();
