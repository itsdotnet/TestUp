using TestUp.Domain.Enums;
using TestUp.WebApi.Models;
using System.Threading.Tasks;
using TestUp.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TestUp.Service.Interfaces;
using TestUp.Service.DTOs.Question;

namespace TestUp.WebApi.Controllers;

public class QuestionsController : BaseController
{
    private readonly IQuestionService questionService;

    public QuestionsController(IQuestionService questionService)
    {
        this.questionService = questionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(QuestionCreationDto dto)
    {
        var titlevalid = Validator.IsValidText(dto.Title);
        var descriptvalid = Validator.IsValidDescription(dto.Description);

        if (titlevalid && descriptvalid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.questionService.CreateAsync(dto)
            });
        return BadRequest(new Response
        {
            StatusCode = 400,
            Message = "Title or Description invalid",
        });
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(QuestionUpdateDto dto)
    {
        var titlevalid = Validator.IsValidText(dto.Title);
        var descriptvalid = Validator.IsValidDescription(dto.Description);

        if (titlevalid && descriptvalid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.questionService.ModifyAsync(dto)
            });

        return BadRequest(new Response
        {
            StatusCode = 400,
            Message = "Title or Description invalid",
        });
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.GetAllAsync()
        });

    [HttpPut("update-image")]
    public async Task<IActionResult> PutImageAsync(long id, IFormFile image)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succsess",
            Data = await this.questionService.ModifyImageAsync(id, image)
        });

    [HttpGet("get-userid/{userId:long}")]
    public async Task<IActionResult> GetByUserIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.GetByUserIdAsync(userId)
        });

    [HttpGet("get-level")]
    public async Task<IActionResult> GetByLevelAsync(long userId, Level level)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.GetByLevelAsync(userId, level)
        });

    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(string searchTerm)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.questionService.SearchAsync(searchTerm)
        });
}