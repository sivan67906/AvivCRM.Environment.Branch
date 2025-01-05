using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Application.Features.Applicationss.CreateApplication;
using AvivCRM.Environment.Application.Features.Applicationss.DeleteApplication;
using AvivCRM.Environment.Application.Features.Applicationss.GetAllApplication;
using AvivCRM.Environment.Application.Features.Applicationss.GetApplicationById;
using AvivCRM.Environment.Application.Features.Applicationss.UpdateApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly ISender _sender;
    public ApplicationController(ISender sender) => _sender = sender;

    [HttpGet("all-application")]
    public async Task<IActionResult> GetAllAsync()
    {
        var applicationList = await _sender.Send(new GetAllApplicationQuery());
        return Ok(applicationList);
    }

    [HttpGet("byid-application")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetApplicationByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("create-application")]
    public async Task<IActionResult> CreateAsync(CreateApplicationRequest application)
    {
        var result = await _sender.Send(new CreateApplicationCommand(application));
        return Ok(result);
    }

    [HttpPut("update-application")]
    public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest application)
    {
        var result = await _sender.Send(new UpdateApplicationCommand(application));
        return Ok(result);
    }

    [HttpDelete("delete-application")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteApplicationCommand(Id));
        return Ok(result);
    }
}
