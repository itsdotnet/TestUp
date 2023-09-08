using System.Text;
using TestUp.Service.Helpers;
using System.Security.Claims;
using TestUp.Service.Interfaces;
using TestUp.Service.Exceptions;
using Microsoft.IdentityModel.Tokens;
using TestUp.DataAccess.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace TestUp.Service.Services;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IConfiguration configuration;
    private readonly IRepository<User> userRepository;

    public AuthService(IRepository<User> userRepository, IMemoryCache memoryCache, IConfiguration configuration)
    {
        _memoryCache = memoryCache;
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public string GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (tokenHandler.CanReadToken(token))
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id");

            if (idClaim != null)
            {
                return idClaim.Value;
            }
        }

        return null;
    }

    public async Task<string> GenerateAndCacheTokenByEmailAsync(string email, string password)
    {
        var user = await this.userRepository.SelectAsync(u => u.Email.Equals(email));
        if (user is null)
            throw new NotFoundException("This user is not found");

        bool verifiedPassword = password.Verify(user.Password);
        if (!verifiedPassword)
            throw new CustomException(400, "Password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim("Email", user.Email),
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.UserRole.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);

        _memoryCache.Set(user.Id.ToString(), result, TimeSpan.FromDays(1));

        return result;
    }

    public async Task<string> GenerateAndCacheTokenByUsernameAsync(string username, string password)
    {
        var user = await this.userRepository.SelectAsync(u => u.Username.Equals(username));
        if (user is null)
            throw new NotFoundException("This user is not found");

        bool verifiedPassword = password.Verify(user.Password);
        if (!verifiedPassword)
            throw new CustomException(400, "Password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim("Username", user.Username),
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.UserRole.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);

        _memoryCache.Set(user.Id.ToString(), result, TimeSpan.FromDays(1));

        return result;
    }
}