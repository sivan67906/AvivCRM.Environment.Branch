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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetJobApplicationPositionByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateJobApplicationPositionRequest jobApplicationPosition)
    {
        var result = await _sender.Send(new CreateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateJobApplicationPositionRequest jobApplicationPosition)
    {
        var result = await _sender.Send(new UpdateJobApplicationPositionCommand(jobApplicationPosition));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var jobApplicationPositionList = await _sender.Send(new GetAllJobApplicationPositionQuery());
        return Ok(jobApplicationPositionList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteJobApplicationPositionCommand(Id));
        return Ok(result);
    }
}

















