using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;

public record CreateLeadCategoryCommand(CreateLeadCategoryRequest LeadCategory) : IRequest<ServerResponse>;