#region

using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.CreateProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.DeleteProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.UpdateProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.Query.GetAllProjectReminderPerson;
using AvivCRM.Environment.Application.Features.ProjectReminderPersons.Query.GetProjectReminderPersonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectReminderPersonController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectReminderPersonController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-projectreminderperson")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse projectReminderPersonList = await _sender.Send(new GetAllProjectReminderPersonQuery());
        return Ok(projectReminderPersonList);
    }

    [HttpGet("byid-projectreminderperson")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetProjectReminderPersonByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-projectreminderperson")]
    public async Task<IActionResult> CreateAsync(CreateProjectReminderPersonRequest projectReminderPerson)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateProjectReminderPersonCommand(projectReminderPerson));
        return Ok(result);
    }

    [HttpPut("update-projectreminderperson")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectReminderPersonRequest projectReminderPerson)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateProjectReminderPersonCommand(projectReminderPerson));
        return Ok(result);
    }

    [HttpDelete("delete-projectreminderperson")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteProjectReminderPersonCommand(Id));
        return Ok(result);
    }
}