using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.Features.ProjectCategories.CreateProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.DeleteProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.GetAllProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.GetProjectCategoryById;
using AvivCRM.Environment.Application.Features.ProjectCategories.UpdateProjectCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectCategoryController : ControllerBase
{

    private readonly ISender _sender;
    public ProjectCategoryController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetProjectCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateProjectCategoryRequest projectCategory)
    {
        var result = await _sender.Send(new CreateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectCategoryRequest projectCategory)
    {
        var result = await _sender.Send(new UpdateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var projectCategoryList = await _sender.Send(new GetAllProjectCategoryQuery());
        return Ok(projectCategoryList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteProjectCategoryCommand(Id));
        return Ok(result);
    }
}