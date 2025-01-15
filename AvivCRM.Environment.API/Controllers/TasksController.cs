using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Application.Features.Taskss.Command.CreateTask;
using AvivCRM.Environment.Application.Features.Taskss.Command.DeleteTask;
using AvivCRM.Environment.Application.Features.Taskss.Command.UpdateTask;
using AvivCRM.Environment.Application.Features.Taskss.Query.GetAllTask;
using AvivCRM.Environment.Application.Features.Taskss.Query.GetTaskById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("all-tasks")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse tasksList = await _sender.Send(new GetAllTasksQuery());
        return Ok(tasksList);
    }

    [HttpGet("byid-tasks")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTasksByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-tasks")]
    public async Task<IActionResult> CreateAsync(CreateTasksRequest tasks)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTasksCommand(tasks));
        return Ok(result);
    }

    [HttpPut("update-tasks")]
    public async Task<IActionResult> UpdateAsync(UpdateTasksRequest tasks)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTasksCommand(tasks));
        return Ok(result);
    }

    [HttpDelete("delete-tasks")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTasksCommand(Id));
        return Ok(result);
    }
}
