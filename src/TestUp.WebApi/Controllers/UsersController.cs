using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUp.Service.DTOs.User;
using TestUp.Service.Helpers;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Filters;
using TestUp.WebApi.Models;

namespace TestUp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[DynamicAuthorize]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
    {
        var emailValid = Validator.IsValidEmail(dto.Email);
        var usernameValid = Validator.IsValidUsername(dto.Username);
        var passwordValid = Validator.IsValidPassword(dto.Password);
        var nameValid = Validator.IsValidName(dto.FirstName);
        var surnameValid = Validator.IsValidName(dto.LastName);

        if (emailValid && usernameValid && passwordValid && nameValid && surnameValid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.CreateAsync(dto)
            });

        return BadRequest("Invalid information");
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserUpdateDto dto)
    {
        var usernameValid = Validator.IsValidUsername(dto.Username);
        var nameValid = Validator.IsValidName(dto.FirstName);
        var surnameValid = Validator.IsValidName(dto.LastName);

        if (usernameValid && nameValid && surnameValid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.ModifyAsync(dto)
            });

        return BadRequest("Invalid information");
    }

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
    {
        var oldPasswordValid = Validator.IsValidName(oldPass);
        var newPasswordValid = Validator.IsValidName(newPass);

        if (oldPasswordValid && newPasswordValid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.ModifyPasswordAsync(id, oldPass, newPass)
            });

        return BadRequest("Invalid new or old password");
    }
}