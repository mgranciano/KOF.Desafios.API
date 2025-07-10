using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Application.Services.Desafios;
using KOF.Desafios.Infrastructure.Data;
using KOF.Desafios.Infrastructure.Repositories;
using KOF.Desafios.PublicAPI.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KOF.Desafios.API",
        Version = "v1",
        Description = "API inicial del proyecto KOF Desafíos"
    });
});

var app = builder.Build();
Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

app.UseStaticFiles();
// Middlewares básicos
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet("/swagger-ui/custom.css");
        });
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDesafiosRepository, DesafiosRepository>();
builder.Services.AddScoped<IDesafiosService, DesafiosService>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public partial class Program { }