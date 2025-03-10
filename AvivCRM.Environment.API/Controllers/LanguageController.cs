﻿#region

using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Application.Features.Languages.Command.CreateLanguage;
using AvivCRM.Environment.Application.Features.Languages.Command.DeleteLanguage;
using AvivCRM.Environment.Application.Features.Languages.Command.UpdateLanguage;
using AvivCRM.Environment.Application.Features.Languages.Query.GetAllLanguage;
using AvivCRM.Environment.Application.Features.Languages.Query.GetLanguageById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ISender _sender;

    public LanguageController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-language")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse languageList = await _sender.Send(new GetAllLanguagesQuery());
        return Ok(languageList);
    }

    [HttpGet("byid-language")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetLanguageByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-language")]
    public async Task<IActionResult> CreateAsync(createLanguageRequest language)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateLanguageCommand(language));
        return Ok(result);
    }

    [HttpPut("update-language")]
    public async Task<IActionResult> UpdateAsync(UpdateLanguageRequest language)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateLanguageCommand(language));
        return Ok(result);
    }

    [HttpDelete("delete-language")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteLanguageCommand(Id));
        return Ok(result);
    }
}