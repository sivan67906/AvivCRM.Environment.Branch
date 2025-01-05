using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.CreateCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.DeleteCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetAllCustomQuestionCategory;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetCustomQuestionCategoryById;
using AvivCRM.Environment.Application.Features.CustomQuestionCategories.UpdateCustomQuestionCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomQuestionCategoryController : ControllerBase
{

    private readonly ISender _sender;
    public CustomQuestionCategoryController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetCustomQuestionCategoryByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCustomQuestionCategoryRequest customQuestionCategory)
    {
        var result = await _sender.Send(new CreateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCustomQuestionCategoryRequest customQuestionCategory)
    {
        var result = await _sender.Send(new UpdateCustomQuestionCategoryCommand(customQuestionCategory));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var customQuestionCategoryList = await _sender.Send(new GetAllCustomQuestionCategoryQuery());
        return Ok(customQuestionCategoryList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteCustomQuestionCategoryCommand(Id));
        return Ok(result);
    }
}









