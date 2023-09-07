using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.Interfaces;
using TestUp.WebApi.Models;

namespace TestUp.WebApi.Controllers;

public class ExamsController : BaseController
{
    private readonly IExamService examService;
    public ExamsController(IExamService examService)
    {
        this.examService = examService;
    }

    [HttpPost("create")]
    [Authorize(Policy = "TeacherPolicy")]
    public async Task<IActionResult> PostAsync(ExamCreationDto examCreation)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.CreateAsync(examCreation)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ExamUpdateDto examUpdate)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.ModifyAsync(examUpdate)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.DeleteAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.GetAllAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.GetByIdAsync(id)
        });

    [HttpGet("get/{title}")]
    public async Task<IActionResult> GetByTitleAsync(string title)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.GetByTitleAsync(title)
        });

    [HttpGet("get-near")]
    public async Task<IActionResult> GetByNearExamAsync([FromQuery] DateTime dateTime)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.GetByNearExamAsync(dateTime)
        });

    [HttpGet("get-ended-exam")]
    public async Task<IActionResult> GetEndExam()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.EndedExams()
        });

    [HttpGet("get-future-exam")]
    public async Task<IActionResult> GetFutureExam()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.FutureExams()
        });

    [HttpGet("get-current-exam")]
    public async Task<IActionResult> GetCurrentExam()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await this.examService.CurrentExams()
        });
}
