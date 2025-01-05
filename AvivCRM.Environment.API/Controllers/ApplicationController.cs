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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetApplicationByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateApplicationRequest application)
    {
        var result = await _sender.Send(new CreateApplicationCommand(application));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateApplicationRequest application)
    {
        await _sender.Send(new UpdateApplicationCommand(application));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var applicationList = await _sender.Send(new GetAllApplicationQuery());
        return Ok(applicationList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteApplicationCommand(Id));
        return NoContent();
    }
}
