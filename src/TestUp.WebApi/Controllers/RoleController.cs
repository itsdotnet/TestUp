using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUp.Service.Enums;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Models;

namespace TestUp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RoleController : ControllerBase
{
    private readonly IRolesService rolesService;
    public RoleController(IRolesService rolesService)
    {
        this.rolesService = rolesService;
    }
    [HttpPost("role")]
    public async Task<IActionResult> PostRole(UserRolle userRolle)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.rolesService.ExchangeRole(userRolle)
        });
}
