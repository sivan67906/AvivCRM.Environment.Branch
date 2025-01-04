using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.CreateCustomQuestionPosition;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.DeleteCustomQuestionPosition;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetAllCustomQuestionPosition;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetCustomQuestionPositionById;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.UpdateCustomQuestionPosition;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomQuestionPositionController : ControllerBase
{

    private readonly ISender _sender;
    public CustomQuestionPositionController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetCustomQuestionPositionByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCustomQuestionPositionRequest customQuestionPosition)
    {
        var result = await _sender.Send(new CreateCustomQuestionPositionCommand(customQuestionPosition));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCustomQuestionPositionRequest customQuestionPosition)
    {
        await _sender.Send(new UpdateCustomQuestionPositionCommand(customQuestionPosition));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var customQuestionPositionList = await _sender.Send(new GetAllCustomQuestionPositionQuery());
        return Ok(customQuestionPositionList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteCustomQuestionPositionCommand(Id));
        return NoContent();
    }
}









