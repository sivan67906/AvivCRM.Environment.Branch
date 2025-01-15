#region

using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.Command.CreateLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.Command.DeleteLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.Command.UpdateLeadCategory;
using AvivCRM.Environment.Application.Features.LeadCategories.Query.GetAllLeadCategories;
using AvivCRM.Environment.Application.Features.LeadCategories.Query.GetLeadCategoryById;
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
        Domain.Responses.ServerResponse leadCategoryList = await _sender.Send(new GetAllLeadCategoryQuery());
        return Ok(leadCategoryList);
    }

    [HttpGet("byid-leadcategory")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetLeadCategoryByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadcategory")]
    public async Task<IActionResult> CreateAsync(CreateLeadCategoryRequest leadCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpPut("update-leadcategory")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadCategoryRequest leadCategory)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateLeadCategoryCommand(leadCategory));
        return Ok(result);
    }

    [HttpDelete("delete-leadcategory")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteLeadCategoryCommand(Id));
        return Ok(result);
    }
}