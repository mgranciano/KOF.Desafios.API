

using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Application.Desafios.Dto;
using Microsoft.Extensions.DependencyInjection;
using KOF.Desafios.Domain.Entities;
using KOF.Desafios.Domain.Entities.Desafios;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Application.Dtos.Desafios.Request;

namespace KOF.Desafios.Application.Common.Mappings
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddCustomMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<DesafioDto, Desafio>, ExpressionTreeMapper<DesafioDto, Desafio>>();
            services.AddScoped<IMapper<Desafio, DesafioDto>, ExpressionTreeMapper<Desafio, DesafioDto>>();
            services.AddScoped<IMapper<InformacionGeneral, InformacionGeneralDto>, ExpressionTreeMapper<InformacionGeneral, InformacionGeneralDto>>();

            services.AddScoped<IMapper<DesafioRequest, DesafioRequestDto>, ExpressionTreeMapper<DesafioRequest, DesafioRequestDto>>();
            services.AddScoped<IMapper<RequestBase, RequestBaseDto>, ExpressionTreeMapper<RequestBase, RequestBaseDto>>();


            return services;
        }
    }
}