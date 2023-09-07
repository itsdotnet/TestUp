namespace TestUp.Service.Interfaces;

public interface IAuthService
{
    string GetUserIdFromToken(string token);
    Task<string> GenerateAndCacheTokenAsync(string email, string password);
}