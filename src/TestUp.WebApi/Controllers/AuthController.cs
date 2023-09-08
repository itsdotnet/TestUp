using TestUp.WebApi.Models;
using System.Threading.Tasks;
using TestUp.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;

public class AuthController : BaseController
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> AuthenticateAsync(string emailOrUsername, string password)
    {
        if (Validator.IsValidEmail(emailOrUsername))
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.authService.GenerateAndCacheTokenByEmailAsync(emailOrUsername, password)
            });

        }else if (Validator.IsValidPassword(password))
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.authService.GenerateAndCacheTokenByUsernameAsync(emailOrUsername, password)
            });
        }

        return BadRequest("Username or password is incorrect");
    }
}