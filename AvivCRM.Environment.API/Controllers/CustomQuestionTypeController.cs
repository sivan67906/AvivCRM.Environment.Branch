using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.Command.CreateCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.Command.DeleteCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.Command.UpdateCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.Query.GetAllCustomQuestionType;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.Query.GetCustomQuestionTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomQuestionTypeController : ControllerBase
{

    private readonly ISender _sender;
    public CustomQuestionTypeController(ISender sender) => _sender = sender;

    [HttpGet("all-customquestiontype")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse customQuestionTypeList = await _sender.Send(new GetAllCustomQuestionTypeQuery());
        return Ok(customQuestionTypeList);
    }

    [HttpGet("byid-customquestiontype")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetCustomQuestionTypeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-customquestiontype")]
    public async Task<IActionResult> CreateAsync(CreateCustomQuestionTypeRequest customQuestionType)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpPut("update-customquestiontype")]
    public async Task<IActionResult> UpdateAsync(UpdateCustomQuestionTypeRequest customQuestionType)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpDelete("delete-customquestiontype")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteCustomQuestionTypeCommand(Id));
        return Ok(result);
    }
}






















