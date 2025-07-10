using System;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Application.Services.Desafios;

public class DesafiosService : IDesafiosService
{
    private readonly IDesafiosRepository _desafioRepository;

    public DesafiosService(IDesafiosRepository desafioRepository)
    {
        _desafioRepository = desafioRepository;
    }

    public async Task<InformacionGeneralDto> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
    {
        var desafio = await _desafioRepository.GetAllChallenges(idDesafio, idCliente, idPais);
        if (desafio == null)
        {
            return null;
        }

        return new InformacionGeneralDto
        {
            IdPais = idPais,
            IdSegmentacion = desafio.IdSegmentacion,
            IdDesafio = desafio.IdDesafio,
            TituloDesafio = desafio.TituloDesafio,
            LogotipoDesafio = desafio.LogotipoDesafio,
            DescripcionDesafio = desafio.DescripcionDesafio,
            Promocion = desafio.Promocion,
            PuntosExtra = desafio.PuntosExtra,
            FechaInicio = desafio.FechaInicio.ToString("yyyy-MM-dd"),
            FechaFinalizacion = desafio.FechaFinalizacion.ToString("yyyy-MM-dd"),
            Estatus = desafio.Estatus,
            JsonMateriales = desafio.JsonMateriales
        };
    }
}
