using FluentValidation;
using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Interfaces;
using KOF.Desafios.Application.Desafios.Validators;
using KOF.Desafios.Application.Auth.Interfaces;
using KOF.Desafios.Infrastructure.Desafios.Services;
using KOF.Desafios.Infrastructure.Auth.Services;
using KOF.Desafios.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Logging;
using KOF.Desafios.Infrastructure.Common.Logging;
using KOF.Desafios.Application.Common.Context;

namespace KOF.Desafios.PublicAPI.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IValidator<DesafioDto>, DesafioDtoValidator>();

        services.AddScoped<RequestContext>();

        services.AddCustomMappers();

        return services;
    }
}