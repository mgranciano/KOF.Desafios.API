using System;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Application.Dtos.Desafios;
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

    public async Task<List<InformacionGeneralDto>> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
    {
        var desafio = await _desafioRepository.GetAllChallenges(idDesafio, idCliente, idPais);

        if (desafio == null || !desafio.Any())
        {
            return new List<InformacionGeneralDto>();
        }

        var dto = _mapper.Map(desafio);


        return dto;
    }
}
