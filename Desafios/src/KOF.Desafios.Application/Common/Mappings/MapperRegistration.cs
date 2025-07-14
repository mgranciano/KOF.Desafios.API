

using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Application.Desafios.Dto;
using Microsoft.Extensions.DependencyInjection;
using KOF.Desafios.Domain.Entities;

namespace KOF.Desafios.Application.Common.Mappings
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddCustomMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<DesafioDto, Desafio>, ExpressionTreeMapper<DesafioDto, Desafio>>();
            services.AddScoped<IMapper<Desafio, DesafioDto>, ExpressionTreeMapper<Desafio, DesafioDto>>();
            return services;
        }
    }
}