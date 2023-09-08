namespace TestUp.Service.Interfaces;

public interface IAuthService
{
    string GetUserIdFromToken(string token);
    Task<string> GenerateAndCacheTokenByEmailAsync(string email, string password);
    Task<string> GenerateAndCacheTokenByUsernameAsync(string username, string password);
}