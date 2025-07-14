using System;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Application.Validators;
using KOF.Desafios.Application.Validators.Desafios;
using KOF.Desafios.Domain.Common.Enums;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Application.Services.Desafios;

public class DesafiosService : IDesafiosService
{
    private readonly IMapper<List<InformacionGeneral>, List<InformacionGeneralDto>> _mapper = new ExpressionTreeMapper<List<InformacionGeneral>, List<InformacionGeneralDto>>();

    private readonly IDesafiosRepository _desafioRepository;


    public DesafiosService(IDesafiosRepository desafioRepository)
    {
        _desafioRepository = desafioRepository;
    }

    public async Task<List<InformacionGeneralDto>> GetAllChallenges(DesafioRequestDto request)
    {
        var req = new DesafioRequest
        {
            IdPais = request.IdPais,
            IdSegmentacion = request.IdSegmentacion,
            Estatus = request.Estatus,
            Pagina = request.Pagina,
            TamanoPagina = request.TamanoPagina
        };
        var desafio = await _desafioRepository.GetAllChallenges(req);

        if (desafio == null || !desafio.Any())
        {
            return new List<InformacionGeneralDto>();
        }

        // var dto = _mapper.Map(desafio);

        var dto = desafio.Select(d => new InformacionGeneralDto
        {
            DescripcionDesafio = d.DescripcionDesafio,
            IdDesafio = d.IdDesafio,
            IdSegmentacion = d.IdSegmentacion,
            Estatus = d.Estatus,
            FechaCreacion = d.FechaCreacion,
            FechaCancela = d.FechaCancela,
            FechaCierre = d.FechaCierre,
            FechaFinalizacion = d.FechaFinalizacion,
            FechaInicio = d.FechaInicio,
            FechaPublicacion = d.FechaPublicacion,
            JsonMateriales = d.JsonMateriales,
            LogotipoDesafio = d.LogotipoDesafio,
            Promocion = d.Promocion,
            TituloDesafio = d.TituloDesafio,
            UsuarioCreacion = d.UsuarioCreacion,
            UsuarioCierre = d.UsuarioCierre,
            UsuarioPublicacion = d.UsuarioPublicacion
        }).ToList();

        return dto;
    }
}
