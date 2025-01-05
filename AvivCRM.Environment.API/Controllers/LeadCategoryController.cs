using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.DeleteLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.GetAllLeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.GetLeadCategoryById;
using AvivCRM.Environment.Application.Features.LeadCategories.UpdateLeadCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadCategoryController : ControllerBase
{
    private readonly ISender _sender;
    public LeadCategoryController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetLeadCategoryByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateLeadCategoryRequest leadCategory)
    {
        var result = await _sender.Send(new CreateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateLeadCategoryRequest leadCategory)
    {
        var result = await _sender.Send(new UpdateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var leadCategoryList = await _sender.Send(new GetAllLeadCategoryQuery());
        return Ok(leadCategoryList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadCategoryCommand(Id));
        return Ok(result);
    }
}
