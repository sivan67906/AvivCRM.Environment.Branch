#region

using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Application.Features.Applicationss.Command.CreateApplication;
using AvivCRM.Environment.Application.Features.Applicationss.Command.DeleteApplication;
using AvivCRM.Environment.Application.Features.Applicationss.Command.UpdateApplication;
using AvivCRM.Environment.Application.Features.Applicationss.Query.GetAllApplication;
using AvivCRM.Environment.Application.Features.Applicationss.Query.GetApplicationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly ISender _sender;

    public ApplicationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-application")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse applicationList = await _sender.Send(new GetAllApplicationQuery());
        return Ok(applicationList);
    }

    [HttpGet("byid-application")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetApplicationByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("create-application")]
    public async Task<IActionResult> CreateAsync(CreateApplicationRequest application)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateApplicationCommand(application));
        return Ok(result);
    }

    [HttpPut("update-application")]
    public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest application)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateApplicationCommand(application));
        return Ok(result);
    }

    [HttpDelete("delete-application")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteApplicationCommand(Id));
        return Ok(result);
    }
}