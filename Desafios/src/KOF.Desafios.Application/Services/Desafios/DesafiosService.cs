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
    private readonly IMapper<InformacionGeneral, InformacionGeneralDto> _mapper = new ExpressionTreeMapper<InformacionGeneral, InformacionGeneralDto>();
    private readonly IDesafiosRepository _desafioRepository;
    private readonly IValidatorOrquestador _validatorOrquestador;

    public DesafiosService(IDesafiosRepository desafioRepository, IValidatorOrquestador validatorOrquestador)
    {
        _desafioRepository = desafioRepository;
        _validatorOrquestador = validatorOrquestador;
    }

    public async Task<InformacionGeneralDto> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
    {
        var desafio = await _desafioRepository.GetAllChallenges(idDesafio, idCliente, idPais);

        if (desafio == null)
        {
            return null;
        }
        var dto = _mapper.Map(desafio);
        
        await _validatorOrquestador.ValidateAsync(dto, Operacion.Read);

        return dto;
    }
}
