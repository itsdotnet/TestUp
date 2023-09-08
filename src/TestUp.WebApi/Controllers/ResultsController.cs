using TestUp.WebApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestUp.Service.Interfaces;
using TestUp.Service.DTOs.Result;

namespace TestUp.WebApi.Controllers;

public class ResultsController : BaseController
{
    private readonly IResultService resultService;

    public ResultsController(IResultService resultService)
    {
        this.resultService = resultService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ResultCrestionDto dto)
     => Ok(new Response
     {
         StatusCode = 200,
         Message = "Success",
         Data = await this.resultService.CreateAsync(dto)
     });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ResultUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.UpdateAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.GetAllAsync()
        });

    [HttpGet("get-userid/{userId:long}")]
    public async Task<IActionResult> GetByUserIdAsync(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.GetByUserId(userId)
        });

    [HttpGet("get-examId/{examId:long}")]
    public async Task<IActionResult> GetByExamIdAsync(long examId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.GetByExamId(examId)
        });

    [HttpGet("myScore")]
    public async Task<IActionResult> MyScoreAsync(long userId, long examId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.resultService.MyScore(userId, examId)
        });
}