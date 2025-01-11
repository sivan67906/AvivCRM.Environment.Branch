using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.CreateJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.DeleteJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.GetAllJobApplicationPosition;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.GetJobApplicationPositionById;
using AvivCRM.Environment.Application.Features.JobApplicationPositions.UpdateJobApplicationPosition;
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
        var jobApplicationPositionList = await _sender.Send(new GetAllJobApplicationPositionQuery());
        return Ok(jobApplicationPositionList);
    }

    [HttpGet("byid-jobapplicationposition")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetJobApplicationPositionByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-jobapplicationposition")]
    public async Task<IActionResult> CreateAsync(CreateJobApplicationPositionRequest jobApplicationPosition)
    {
        var result = await _sender.Send(new CreateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpPut("update-jobapplicationposition")]
    public async Task<IActionResult> UpdateAsync(UpdateJobApplicationPositionRequest jobApplicationPosition)
    {
        var result = await _sender.Send(new UpdateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpDelete("delete-jobapplicationposition")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteJobApplicationPositionCommand(Id));
        return Ok(result);
    }
}






















