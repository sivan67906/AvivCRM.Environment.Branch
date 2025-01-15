using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.CreateJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.DeleteJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.UpdateJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.Query.GetAllJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.Query.GetJobApplicationPositionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationPositionController : ControllerBase
{

    private readonly ISender _sender;
    public JobApplicationPositionController(ISender sender) => _sender = sender;

    [HttpGet("all-jobapplicationposition")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse jobApplicationPositionList = await _sender.Send(new GetAllJobApplicationPositionQuery());
        return Ok(jobApplicationPositionList);
    }

    [HttpGet("byid-jobapplicationposition")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetJobApplicationPositionByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-jobapplicationposition")]
    public async Task<IActionResult> CreateAsync(CreateJobApplicationPositionRequest jobApplicationPosition)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpPut("update-jobapplicationposition")]
    public async Task<IActionResult> UpdateAsync(UpdateJobApplicationPositionRequest jobApplicationPosition)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpDelete("delete-jobapplicationposition")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteJobApplicationPositionCommand(Id));
        return Ok(result);
    }
}






















