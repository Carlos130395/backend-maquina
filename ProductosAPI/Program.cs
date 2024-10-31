using Microsoft.EntityFrameworkCore;
using ProductosAPI.Application.Services;
using ProductosAPI.Domain.Repositories;
using ProductosAPI.Infrastructure.Data;
using ProductosAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.EnableRetryOnFailure()
    ).EnableSensitiveDataLogging(false));

// Registrar Maquinas repositorios y servicios
builder.Services.AddScoped<IMaquinaRepository, MaquinaRepository>();
builder.Services.AddScoped<MaquinaService>();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Permite cualquier origen
               .AllowAnyMethod() // Permite cualquier m�todo (GET, POST, etc.)
               .AllowAnyHeader(); // Permite cualquier encabezado
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar la pol�tica de CORS
app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
