using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Application.Features.Languages.CreateLanguage;
using AvivCRM.Environment.Application.Features.Languages.DeleteLanguage;
using AvivCRM.Environment.Application.Features.Languages.GatAllLanguage;
using AvivCRM.Environment.Application.Features.Languages.GetLanguageById;
using AvivCRM.Environment.Application.Features.Languages.UpdateLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ISender _sender;
    public LanguageController(ISender sender) => _sender = sender;

    [HttpGet("all-language")]
    public async Task<IActionResult> GetAllAsync()
    {
        var languageList = await _sender.Send(new GetAllLanguagesQuery());
        return Ok(languageList);
    }

    [HttpGet("byid-language")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetLanguageByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-language")]
    public async Task<IActionResult> CreateAsync(createLanguageRequest language)
    {
        var result = await _sender.Send(new CreateLanguageCommand(language));
        return Ok(result);
    }

    [HttpPut("update-language")]
    public async Task<IActionResult> UpdateAsync(UpdateLanguageRequest language)
    {
        var result = await _sender.Send(new UpdateLanguageCommand(language));
        return Ok(result);
    }

    [HttpDelete("delete-language")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteLanguageCommand(Id));
        return Ok(result);
    }
}
