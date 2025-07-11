using System;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Application.Interfaces.Desafios;

public interface IDesafiosRepository
{
    Task<List<InformacionGeneral>> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT");
}
