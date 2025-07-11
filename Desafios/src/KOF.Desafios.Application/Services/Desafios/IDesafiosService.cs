using System;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Application.Services.Desafios;

public interface IDesafiosService
{
    Task<List<InformacionGeneralDto>> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT");
}
