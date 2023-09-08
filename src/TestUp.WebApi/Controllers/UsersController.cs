using TestUp.WebApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestUp.Service.DTOs.User;
using TestUp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TestUp.WebApi.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await this.userService.CreateAsync(dto)
    });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetByIdAsync(id)
        });

    [Authorize(Roles = "User")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetAllAsync()
        });

    [HttpGet("get-email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetByEmailAsync(email)
        });

    [HttpGet("get-name")]
    public async Task<IActionResult> GetByNameAsync(string name)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetByName(name)
        });

    [HttpGet("get-username")]
    public async Task<IActionResult> GetByUsernameAsync(string username)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetByUsernameAsync(username)
        });

    [HttpPut("update-password")]
    public async Task<IActionResult> ModifyPasswordAsync(long id, string oldPass, string newPass)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Accsess",
            Data = await this.userService.ModifyPasswordAsync(id, oldPass, newPass)
        });
}