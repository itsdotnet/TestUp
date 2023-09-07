using System.Text;
using TestUp.Service.Helpers;
using System.Security.Claims;
using TestUp.Service.Interfaces;
using TestUp.Service.Exceptions;
using Microsoft.IdentityModel.Tokens;
using TestUp.DataAccess.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace TestUp.Service.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration configuration;
    private readonly IRepository<User> userRepository;

    public AuthService(IRepository<User> userRepository, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(string email, string password)
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
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);
        return result;
    }
}