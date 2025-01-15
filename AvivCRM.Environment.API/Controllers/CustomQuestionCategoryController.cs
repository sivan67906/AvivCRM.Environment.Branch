using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.CreateCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.DeleteCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.UpdateCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.Query.GetAllCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.Query.GetCustomQuestionCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomQuestionCategoryController : ControllerBase
{

    private readonly ISender _sender;
    public CustomQuestionCategoryController(ISender sender) => _sender = sender;

    [HttpGet("all-customquestioncategory")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse customQuestionCategoryList = await _sender.Send(new GetAllCustomQuestionCategoryQuery());
        return Ok(customQuestionCategoryList);
    }

    [HttpGet("byid-customquestioncategory")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetCustomQuestionCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-customquestioncategory")]
    public async Task<IActionResult> CreateAsync(CreateCustomQuestionCategoryRequest customQuestionCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpPut("update-customquestioncategory")]
    public async Task<IActionResult> UpdateAsync(UpdateCustomQuestionCategoryRequest customQuestionCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpDelete("delete-customquestioncategory")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteCustomQuestionCategoryCommand(Id));
        return Ok(result);
    }
}






















