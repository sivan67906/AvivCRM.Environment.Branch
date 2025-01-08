#region

using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.CreateCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.DeleteCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetAllCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetCustomQuestionCategoryById;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.UpdateCustomQuestionCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomQuestionCategoryController : ControllerBase
{
    private readonly ISender _sender;

    public CustomQuestionCategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetCustomQuestionCategoryByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateCustomQuestionCategoryRequest customQuestionCategory)
    {
        var result = await _sender.Send(new CreateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateCustomQuestionCategoryRequest customQuestionCategory)
    {
        var result = await _sender.Send(new UpdateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var customQuestionCategoryList = await _sender.Send(new GetAllCustomQuestionCategoryQuery());
        return Ok(customQuestionCategoryList);
    }


    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteCustomQuestionCategoryCommand(Id));
        return Ok(result);
    }
}