using System;
using FluentValidation;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Application.Common.Validators.Orquestador;
using KOF.Desafios.Application.Desafios.Interfaces;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Application.Services.Desafios;
using KOF.Desafios.Application.Validators.Desafios.Request;
using KOF.Desafios.Infrastructure.Desafios.Services;
using KOF.Desafios.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KOF.Desafios.PublicAPI.Configurations;

public static class ModuleExtensions
{
    public static IServiceCollection AddDesafiosModule(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. DbContext
        services.AddDbContext<DesafiosDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // 2. Repositorios
        services.AddScoped<IDesafiosRepository, DesafiosRepository>();
        services.AddScoped<IDesafioService, DesafiosService>();
        return services;
    }
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        // FluentValidation
        services.AddScoped<IValidator<DesafioRequestDto>, DesafioRequestDtoReadValidator>();
        services.AddScoped<DesafioRequestDtoReadValidator>();

        // Orquestador de validación
        services.AddScoped<IValidatorOrquestador, ValidatorOrquestador>(); // 👈 Registra la implementación
        return services;
    }
}
