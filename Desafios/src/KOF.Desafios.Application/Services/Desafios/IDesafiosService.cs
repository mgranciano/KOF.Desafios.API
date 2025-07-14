using System;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Application.Services.Desafios;

public interface IDesafiosService
{
    Task<List<InformacionGeneralDto>> GetAllChallenges(DesafioRequestDto request);
}
