using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.CreateProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.DeleteProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetAllProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetProjectReminderPersonById;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.UpdateProjectReminderPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectReminderPersonController : ControllerBase
{

    private readonly ISender _sender;
    public ProjectReminderPersonController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetProjectReminderPersonByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProjectReminderPersonRequest projectReminderPerson)
    {
        var result = await _sender.Send(new CreateProjectReminderPersonCommand(projectReminderPerson));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateProjectReminderPersonRequest projectReminderPerson)
    {
        var result = await _sender.Send(new UpdateProjectReminderPersonCommand(projectReminderPerson));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var projectReminderPersonList = await _sender.Send(new GetAllProjectReminderPersonQuery());
        return Ok(projectReminderPersonList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteProjectReminderPersonCommand(Id));
        return Ok(result);
    }
}









