using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Application.Desafios.Dto.Request;
using KOF.Desafios.Application.Desafios.Entities.Request;
using KOF.Desafios.Application.Desafios.Interfaces;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Domain.Entities.Desafios;


namespace KOF.Desafios.Application.Services.Desafios;

public class DesafiosService : IDesafioService
{
    private readonly IDesafiosRepository _desafioRepository;
    public DesafiosService(IDesafiosRepository desafioRepository)
    {
        _desafioRepository = desafioRepository;
    }

    public async Task<InformacionGeneralDto> CreateAsync(InformacionGeneralDto dto)
    {
        var entidad = new InformacionGeneral
        {
            DescripcionDesafio = dto.DescripcionDesafio,
            IdDesafio = dto.IdDesafio,
            IdSegmentacion = dto.IdSegmentacion,
            Estatus = dto.Estatus,
            FechaCreacion = dto.FechaCreacion,
            FechaCancela = dto.FechaCancela,
            FechaCierre = dto.FechaCierre,
            FechaFinalizacion = dto.FechaFinalizacion,
            FechaInicio = dto.FechaInicio,
            FechaPublicacion = dto.FechaPublicacion,
            JsonMateriales = dto.JsonMateriales,
            LogotipoDesafio = dto.LogotipoDesafio,
            Promocion = dto.Promocion,
            TituloDesafio = dto.TituloDesafio,
            UsuarioCreacion = dto.UsuarioCreacion,
            UsuarioCierre = dto.UsuarioCierre,
            UsuarioPublicacion = dto.UsuarioPublicacion,
            PuntosExtra = dto.PuntosExtra,
            UsuarioCancela = dto.UsuarioCancela
        };
        var created = await _desafioRepository.CreateAsync(entidad);
        if (created == null)
        {
            throw new Exception("Error al crear el desafío");
        }

        // var dto = _mapper.MapBack<InformacionGeneralDto>(created);
        var newDto = new InformacionGeneralDto
        {
            DescripcionDesafio = created.DescripcionDesafio,
            IdDesafio = created.IdDesafio,
            IdSegmentacion = created.IdSegmentacion,
            Estatus = created.Estatus,
            FechaCreacion = created.FechaCreacion,
            FechaCancela = created.FechaCancela,
            FechaCierre = created.FechaCierre,
            FechaFinalizacion = created.FechaFinalizacion,
            FechaInicio = created.FechaInicio,
            FechaPublicacion = created.FechaPublicacion,
            JsonMateriales = created.JsonMateriales,
            LogotipoDesafio = created.LogotipoDesafio,
            Promocion = created.Promocion,
            TituloDesafio = created.TituloDesafio,
            UsuarioCreacion = created.UsuarioCreacion,
            UsuarioCierre = created.UsuarioCierre,
            UsuarioPublicacion = created.UsuarioPublicacion,
            PuntosExtra = created.PuntosExtra,
            UsuarioCancela = created.UsuarioCancela
        };
        return newDto;
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _desafioRepository.DeleteAsync(id);
    }

    public async Task<List<InformacionGeneralDto>> GetAllAsync(DesafioRequestDto requestDto)
    {
        var req = new DesafioRequest
        {
            IdPais = requestDto.IdPais,
            IdSegmentacion = requestDto.IdSegmentacion,
            Estatus = requestDto.Estatus,
            Pagina = requestDto.Pagina,
            TamanoPagina = requestDto.TamanoPagina
        };

        var desafio = await _desafioRepository.GetAllAsync(req);

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
            UsuarioPublicacion = d.UsuarioPublicacion,
            PuntosExtra = d.PuntosExtra,
            UsuarioCancela = d.UsuarioCancela
        }).ToList();

        return dto;
    }

    public async Task<InformacionGeneralDto?> GetByIdAsync(int id)
    {
        var desafio = await _desafioRepository.GetByIdAsync(id);
        if (desafio == null)
        {
            return null;
        }
        //  var dto = _mapper.MapBack<InformacionGeneralDto>(desafio);
        var dto = new InformacionGeneralDto
        {
            DescripcionDesafio = desafio.DescripcionDesafio,
            IdDesafio = desafio.IdDesafio,
            IdSegmentacion = desafio.IdSegmentacion,
            Estatus = desafio.Estatus,
            FechaCreacion = desafio.FechaCreacion,
            FechaCancela = desafio.FechaCancela,
            FechaCierre = desafio.FechaCierre,
            FechaFinalizacion = desafio.FechaFinalizacion,
            FechaInicio = desafio.FechaInicio,
            FechaPublicacion = desafio.FechaPublicacion,
            JsonMateriales = desafio.JsonMateriales,
            LogotipoDesafio = desafio.LogotipoDesafio,
            Promocion = desafio.Promocion,
            TituloDesafio = desafio.TituloDesafio,
            UsuarioCreacion = desafio.UsuarioCreacion,
            UsuarioCierre = desafio.UsuarioCierre,
            UsuarioPublicacion = desafio.UsuarioPublicacion,
            PuntosExtra = desafio.PuntosExtra,
            UsuarioCancela = desafio.UsuarioCancela
        };
        return dto;
    }

    public async Task<InformacionGeneralDto> UpdateAsync(int id, InformacionGeneralUpdateDto dto)
    {
        var entidad = new InformacionGeneralUpdate
        {
            IdDesafio = dto.IdDesafio,
            TituloDesafio = dto.TituloDesafio,
            DescripcionDesafio = dto.DescripcionDesafio,
            LogotipoDesafio = dto.LogotipoDesafio,
            Promocion = dto.Promocion,
            PuntosExtra = dto.PuntosExtra
        };
        var updated = await _desafioRepository.UpdateAsync(entidad);
        if (updated == null)
        {
            throw new Exception("Error al actualizar el desafío");
        }
        return new InformacionGeneralDto
        {
            IdDesafio = updated.IdDesafio,
            TituloDesafio = updated.TituloDesafio,
            DescripcionDesafio = updated.DescripcionDesafio,
            LogotipoDesafio = updated.LogotipoDesafio,
            Promocion = updated.Promocion,
            PuntosExtra = updated.PuntosExtra,
            UsuarioCancela = updated.UsuarioCancela,
            Estatus = updated.Estatus,
            FechaCreacion = updated.FechaCreacion,
            FechaCancela = updated.FechaCancela,
            FechaCierre = updated.FechaCierre,
            FechaFinalizacion = updated.FechaFinalizacion,
            FechaInicio = updated.FechaInicio,
            FechaPublicacion = updated.FechaPublicacion,
            IdSegmentacion = updated.IdSegmentacion,
            JsonMateriales = updated.JsonMateriales,
            UsuarioCierre = updated.UsuarioCierre,
            UsuarioCreacion = updated.UsuarioCreacion,
            UsuarioPublicacion = updated.UsuarioPublicacion
        };
    }
}
