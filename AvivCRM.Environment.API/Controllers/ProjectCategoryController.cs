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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetProjectCategoryByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProjectCategoryRequest projectCategory)
    {
        var result = await _sender.Send(new CreateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateProjectCategoryRequest projectCategory)
    {
        var result = await _sender.Send(new UpdateProjectCategoryCommand(projectCategory));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var projectCategoryList = await _sender.Send(new GetAllProjectCategoryQuery());
        return Ok(projectCategoryList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteProjectCategoryCommand(Id));
        return Ok(result);
    }
}









