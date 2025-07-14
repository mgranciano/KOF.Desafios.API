using KOF.Desafios.Application.Desafios.Dto;

namespace KOF.Desafios.Application.Desafios.Interfaces
{
    public interface IDesafioService
    {
        Task<IEnumerable<DesafioDto>> GetAllAsync();
        Task<DesafioDto?> GetByIdAsync(int id);
        Task<DesafioDto> CreateAsync(DesafioDto dto);
        Task<DesafioDto> UpdateAsync(int id, DesafioDto dto);
        Task<bool> DeleteAsync(int id);
    }
}