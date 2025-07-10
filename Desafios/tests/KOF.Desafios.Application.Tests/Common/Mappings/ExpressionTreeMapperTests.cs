using Xunit;
using System;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;

namespace KOF.Desafios.Application.Tests.Common.Mappings
{
    public class ExpressionTreeMapperTests
    {
        public class Desafio
        {
            public int Id { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public DateTime FechaInicio { get; set; }
        }

        public class DesafioDto
        {
            public int Id { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public DateTime FechaInicio { get; set; }
        }

        private readonly IMapper<Desafio, DesafioDto> _mapper = new ExpressionTreeMapper<Desafio, DesafioDto>();

        [Fact]
        public void Should_Map_Desafio_To_DesafioDto()
        {
            var entity = new Desafio
            {
                Id = 1,
                Titulo = "Prueba",
                FechaInicio = new DateTime(2024, 1, 1)
            };

            var dto = _mapper.Map(entity);

            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Titulo, dto.Titulo);
            Assert.Equal(entity.FechaInicio, dto.FechaInicio);
        }

        [Fact]
        public void Should_MapBack_DesafioDto_To_Desafio()
        {
            var dto = new DesafioDto
            {
                Id = 2,
                Titulo = "DTO Test",
                FechaInicio = new DateTime(2025, 7, 9)
            };

            var entity = _mapper.MapBack(dto);

            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Titulo, entity.Titulo);
            Assert.Equal(dto.FechaInicio, entity.FechaInicio);
        }
    }
}