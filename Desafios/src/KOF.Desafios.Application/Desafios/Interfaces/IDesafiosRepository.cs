using System;
using KOF.Desafios.Application.Desafios.Entities.Request;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Domain.Entities.Desafios;


namespace KOF.Desafios.Application.Interfaces.Desafios;

public interface IDesafiosRepository
{
    Task<List<InformacionGeneral>> GetAllAsync(DesafioRequest request);
    Task<InformacionGeneral?> GetByIdAsync(int id);
    Task<InformacionGeneral> CreateAsync(InformacionGeneral desafio);
    Task<InformacionGeneral> UpdateAsync(InformacionGeneralUpdate desafio);
    Task<bool> DeleteAsync(int id);
}
