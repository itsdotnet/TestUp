using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Controllers;
using TestUp.WebApi.Models;

public class AuthController : BaseController
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(string emailOrUsername, string password)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.authService.GenerateAndCacheTokenAsync(emailOrUsername, password)
        });
    }

}