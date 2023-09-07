using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestUp.Service.DTOs.QuestionPack;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Models;

namespace TestUp.WebApi.Controllers;

public class QuestionPacksController : BaseController
{
    private readonly IQuestionPackService questionPackService;
    public QuestionPacksController(IQuestionPackService questionPackService)
    {
        this.questionPackService = questionPackService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(QuestionPackCreationDto questionPackCreationDto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.questionPackService.CreateAsync(questionPackCreationDto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(QuestionPackUpdateDto packUpdateDto)
        => Ok(new Response
        {
            StatusCode=200,
            Message = "Succes",
            Data = await this.questionPackService.ModifyAsync(packUpdateDto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message= "Secces",
            Data = await this.questionPackService.DeleteAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.questionPackService.GetAllAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.questionPackService.GetByIdAsync(id)
        });

    [HttpGet("get-examid/{examId:long}")]
    public async Task<IActionResult> GetByExamIdAsync(long examId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.questionPackService.GetByExamIdAsync(examId)
        });

    [HttpGet("get-collect")]
    public async Task<IActionResult> GetCollectAsync(QuestionPackCollectDto packCollectDto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.questionPackService.CollectAsync(packCollectDto)
        });
}