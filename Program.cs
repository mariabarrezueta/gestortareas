using Gestortareas.Data;
using Gestortareas.Interfaces;
using Gestortareas.Repositories;
using Gestortareas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: permitir acceso desde el frontend publicado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAzureAngularApp",
        policy => policy.WithOrigins("https://gestortareas20250629235635-f8aud6huetdyaqhy.canadacentral-01.azurewebsites.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Inyección de dependencias
builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware en orden correcto
app.UseCors("AllowAzureAngularApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();  // importante para servir index.html
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html"); // SPA fallback

app.Run();


