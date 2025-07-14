namespace KOF.Desafios.Application.Auth.Dto;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}