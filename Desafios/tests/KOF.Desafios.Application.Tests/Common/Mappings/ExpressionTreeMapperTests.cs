using System.Collections.Generic;
using System.Linq;
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
        public void Should_Map_List_Of_Desafio_To_DesafioDto()
        {
            Console.WriteLine("Mapping list of Desafio to DesafioDto...");
            var entities = new List<Desafio>
            {
                new Desafio { Id = 1, Titulo = "Primero", FechaInicio = new DateTime(2024, 1, 1) },
                new Desafio { Id = 2, Titulo = "Segundo", FechaInicio = new DateTime(2024, 2, 1) }
            };
            foreach (var e in entities)
                Console.WriteLine($"ENTIDAD: Id={e.Id}, Titulo={e.Titulo}, FechaInicio={e.FechaInicio}");

            var dtos = entities.Select(e => _mapper.Map(e)).ToList();

            foreach (var d in dtos)
                Console.WriteLine($"DTO: Id={d.Id}, Titulo={d.Titulo}, FechaInicio={d.FechaInicio}");

            Assert.Equal(entities.Count, dtos.Count);
            for (int i = 0; i < entities.Count; i++)
            {
                Assert.Equal(entities[i].Id, dtos[i].Id);
                Assert.Equal(entities[i].Titulo, dtos[i].Titulo);
                Assert.Equal(entities[i].FechaInicio, dtos[i].FechaInicio);
            }
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