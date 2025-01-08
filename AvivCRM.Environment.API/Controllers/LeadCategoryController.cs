#region

using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.DeleteLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.GetAllLeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.GetLeadCategoryById;
using AvivCRM.Environment.Application.Features.LeadCategories.UpdateLeadCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadCategoryController : ControllerBase
{
    private readonly ISender _sender;

    public LeadCategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-leadcategory")]
    public async Task<IActionResult> GetAllAsync()
    {
        var leadCategoryList = await _sender.Send(new GetAllLeadCategoryQuery());
        return Ok(leadCategoryList);
    }

    [HttpGet("byid-leadcategory")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetLeadCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadcategory")]
    public async Task<IActionResult> CreateAsync(CreateLeadCategoryRequest leadCategory)
    {
        var result = await _sender.Send(new CreateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpPut("update-leadcategory")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadCategoryRequest leadCategory)
    {
        var result = await _sender.Send(new UpdateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpDelete("delete-leadcategory")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadCategoryCommand(Id));
        return Ok(result);
    }
}