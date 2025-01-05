using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.CreateCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.DeleteCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetAllCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetCustomQuestionTypeById;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.UpdateCustomQuestionType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomQuestionTypeController : ControllerBase
{

    private readonly ISender _sender;
    public CustomQuestionTypeController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetCustomQuestionTypeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateCustomQuestionTypeRequest customQuestionType)
    {
        var result = await _sender.Send(new CreateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateCustomQuestionTypeRequest customQuestionType)
    {
        var result = await _sender.Send(new UpdateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var customQuestionTypeList = await _sender.Send(new GetAllCustomQuestionTypeQuery());
        return Ok(customQuestionTypeList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteCustomQuestionTypeCommand(Id));
        return Ok(result);
    }
}