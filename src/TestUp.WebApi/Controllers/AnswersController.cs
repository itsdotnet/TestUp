﻿using TestUp.WebApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestUp.Service.Interfaces;
using TestUp.Service.DTOs.Answer;

namespace TestUp.WebApi.Controllers;

public class AnswersController : BaseController
{
    private readonly IAnswerService answerService;

    public AnswersController(IAnswerService answerService)
    {
        this.answerService = answerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AnswerCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AnswerUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetAllAsync()
        });

    [HttpGet("get-questionid")]
    public async Task<IActionResult> GetByQuestionId(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetByQuestionIdAsync(id)
        });
}
