using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
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
    private readonly IMapper<List<InformacionGeneral>, List<InformacionGeneralDto>> _mapper = new ExpressionTreeMapper<List<InformacionGeneral>, List<InformacionGeneralDto>>();
    public DesafiosService(IDesafiosRepository desafioRepository)
    {
        _desafioRepository = desafioRepository;
    }

    public Task<InformacionGeneralDto> CreateAsync(InformacionGeneralDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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
            UsuarioPublicacion = d.UsuarioPublicacion
        }).ToList();

        return dto;
    }

    public Task<InformacionGeneralDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<InformacionGeneralDto> UpdateAsync(int id, InformacionGeneralDto dto)
    {
        throw new NotImplementedException();
    }
}
