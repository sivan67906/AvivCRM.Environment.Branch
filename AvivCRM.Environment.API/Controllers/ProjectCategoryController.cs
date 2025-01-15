#region

using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.Features.ProjectCategories.Command.CreateProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.Command.DeleteProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.Command.UpdateProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.Query.GetAllProjectCategory;
using AvivCRM.Environment.Application.Features.ProjectCategories.Query.GetProjectCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectCategoryController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectCategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-projectcategory")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse projectCategoryList = await _sender.Send(new GetAllProjectCategoryQuery());
        return Ok(projectCategoryList);
    }

    [HttpGet("byid-projectcategory")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetProjectCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-projectcategory")]
    public async Task<IActionResult> CreateAsync(CreateProjectCategoryRequest projectCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpPut("update-projectcategory")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectCategoryRequest projectCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpDelete("delete-projectcategory")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteProjectCategoryCommand(Id));
        return Ok(result);
    }
}