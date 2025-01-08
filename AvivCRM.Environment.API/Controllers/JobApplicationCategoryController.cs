#region

using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.CreateJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.DeleteJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.GetAllJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.GetJobApplicationCategoryById;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.UpdateJobApplicationCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JobApplicationCategoryController : ControllerBase
{
    private readonly ISender _sender;

    public JobApplicationCategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetJobApplicationCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateJobApplicationCategoryRequest jobApplicationCategory)
    {
        var result = await _sender.Send(new CreateJobApplicationCategoryCommand(jobApplicationCategory));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateJobApplicationCategoryRequest jobApplicationCategory)
    {
        var result = await _sender.Send(new UpdateJobApplicationCategoryCommand(jobApplicationCategory));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var jobApplicationCategoryList = await _sender.Send(new GetAllJobApplicationCategoryQuery());
        return Ok(jobApplicationCategoryList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteJobApplicationCategoryCommand(Id));
        return Ok(result);
    }
}