using Microsoft.EntityFrameworkCore;
using InmobiliariaAPI.Endpoints;
using InmobiliariaAPI.Data;
using InmobiliariaAPI.Services;
using InmobiliariaAPI.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddDbContext<PropertyDbContext>(options =>
    options.UseSqlite("Data Source=properties.db"));

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

// Register services
builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Crear la base de datos y aplicar migraciones
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PropertyDbContext>();
    context.Database.EnsureCreated();
    await PropertySeeder.SeedData(context);
}

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// Map endpoints
app.MapPropertyEndpoints();

app.Run();
