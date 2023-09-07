namespace TestUp.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string email, string password);
}