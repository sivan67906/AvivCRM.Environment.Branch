using MediatR;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadCategories.UpdateLeadCategory;

public record UpdateLeadCategoryCommand(UpdateLeadCategoryRequest LeadCategory) : IRequest<ServerResponse>;