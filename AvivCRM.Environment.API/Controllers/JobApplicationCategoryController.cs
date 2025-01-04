using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.CreateJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.DeleteJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.GetAllJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.GetJobApplicationCategoryById;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.UpdateJobApplicationCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationCategoryController : ControllerBase
{

    private readonly ISender _sender;
    public JobApplicationCategoryController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetJobApplicationCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateJobApplicationCategoryRequest jobApplicationCategory)
    {
        var result = await _sender.Send(new CreateJobApplicationCategoryCommand(jobApplicationCategory));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateJobApplicationCategoryRequest jobApplicationCategory)
    {
        await _sender.Send(new UpdateJobApplicationCategoryCommand(jobApplicationCategory));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var jobApplicationCategoryList = await _sender.Send(new GetAllJobApplicationCategoryQuery());
        return Ok(jobApplicationCategoryList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteJobApplicationCategoryCommand(Id));
        return NoContent();
    }
}
