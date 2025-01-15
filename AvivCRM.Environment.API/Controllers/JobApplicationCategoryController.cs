using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.CreateJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.DeleteJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.UpdateJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.Query.GetAllJobApplicationCategory;
using AvivCRM.Environment.Application.Features.JobApplicationCategories.Query.GetJobApplicationCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationCategoryController : ControllerBase
{

    private readonly ISender _sender;
    public JobApplicationCategoryController(ISender sender) => _sender = sender;

    [HttpGet("all-jobapplicationcategory")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse jobApplicationCategoryList = await _sender.Send(new GetAllJobApplicationCategoryQuery());
        return Ok(jobApplicationCategoryList);
    }

    [HttpGet("byid-jobapplicationcategory")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetJobApplicationCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-jobapplicationcategory")]
    public async Task<IActionResult> CreateAsync(CreateJobApplicationCategoryRequest jobApplicationCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateJobApplicationCategoryCommand(jobApplicationCategory));
        return Ok(result);
    }

    [HttpPut("update-jobapplicationcategory")]
    public async Task<IActionResult> UpdateAsync(UpdateJobApplicationCategoryRequest jobApplicationCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateJobApplicationCategoryCommand(jobApplicationCategory));
        return Ok(result);
    }

    [HttpDelete("delete-jobapplicationcategory")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteJobApplicationCategoryCommand(Id));
        return Ok(result);
    }
}






















