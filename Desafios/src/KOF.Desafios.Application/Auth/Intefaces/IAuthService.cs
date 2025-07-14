using KOF.Desafios.Application.Auth.Dto;

namespace KOF.Desafios.Application.Auth.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> AuthenticateAsync(LoginRequest request);
}