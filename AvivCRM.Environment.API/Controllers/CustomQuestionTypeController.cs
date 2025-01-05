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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetCustomQuestionTypeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCustomQuestionTypeRequest customQuestionType)
    {
        var result = await _sender.Send(new CreateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCustomQuestionTypeRequest customQuestionType)
    {
        var result = await _sender.Send(new UpdateCustomQuestionTypeCommand(customQuestionType));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var customQuestionTypeList = await _sender.Send(new GetAllCustomQuestionTypeQuery());
        return Ok(customQuestionTypeList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteCustomQuestionTypeCommand(Id));
        return Ok(result);
    }
}