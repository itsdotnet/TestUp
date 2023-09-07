using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUp.Service.DTOs.UserAnswer;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Models;

namespace TestUp.WebApi.Controllers;

public class UserAnswersController : BaseController
{
    private readonly IUserAnswerService userAnswerService;
    public UserAnswersController(IUserAnswerService userAnswerService)
    {
        this.userAnswerService = userAnswerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(UserAnswerCreationDto answerCreationDto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.userAnswerService.CreateAsync(answerCreationDto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserAnswerUpdateDto userAnswerUpdate)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.userAnswerService.ModifyAsync(userAnswerUpdate)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.userAnswerService.DeleteAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.userAnswerService.GetAllAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.userAnswerService.GetByIdAsync(id)
        });

    [HttpGet("get/{examid:long}")]
    public async Task<IActionResult> GetByExamIdAsync(long examId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.userAnswerService.GetByExamIdAsync(examId)
        });

    [HttpGet("get/{userid:long}")]
    public async Task<IActionResult> GetByUserIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.userAnswerService.GetByUserIdAsync(userId)
        });

    [HttpGet("get/{answerid:long}")]
    public async Task<IActionResult> GetByAnswerIdAsync(long answerId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = this.userAnswerService.GetByAnswerIdAsync(answerId)
        });
}
