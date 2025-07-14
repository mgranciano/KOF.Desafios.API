using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Dto.Request;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;

namespace KOF.Desafios.Application.Desafios.Interfaces
{
    public interface IDesafioService
    {
        Task<List<InformacionGeneralDto>> GetAllAsync(DesafioRequestDto requestDto);
        Task<InformacionGeneralDto?> GetByIdAsync(int id);
        Task<InformacionGeneralDto> CreateAsync(InformacionGeneralDto dto);
        Task<InformacionGeneralDto> UpdateAsync(int id, InformacionGeneralUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}