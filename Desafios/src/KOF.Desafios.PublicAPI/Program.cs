using FluentValidation;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Application.Common.Validators.Orquestador;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Application.Services.Desafios;
using KOF.Desafios.Application.Validators.Desafios;
using KOF.Desafios.Application.Validators.Desafios.Request;
using KOF.Desafios.Infrastructure.Repositories;
using KOF.Desafios.Infrastructure.Repositories.Persistence;
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
builder.Services.AddDbContext<AppDesafiosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDesafiosRepository, DesafiosRepository>();
builder.Services.AddScoped<IDesafiosService, DesafiosService>();

// FluentValidation
builder.Services.AddScoped<IValidator<InformacionGeneralDto>, InformacionGeneralDtoReadValidator>();
builder.Services.AddScoped<InformacionGeneralDtoReadValidator>();
builder.Services.AddScoped<IValidator<DesafioRequestDto>, DesafioRequestDtoReadValidator>();
builder.Services.AddScoped<DesafioRequestDtoReadValidator>();

// Orquestador
builder.Services.AddScoped<IValidatorOrquestador, ValidatorOrquestador>();

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public partial class Program { }