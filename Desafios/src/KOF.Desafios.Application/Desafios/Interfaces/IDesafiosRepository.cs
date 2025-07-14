using System;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Domain.Entities.Desafios;


namespace KOF.Desafios.Application.Interfaces.Desafios;

public interface IDesafiosRepository
{
    Task<List<InformacionGeneral>> GetAllAsync(DesafioRequest request);
}
