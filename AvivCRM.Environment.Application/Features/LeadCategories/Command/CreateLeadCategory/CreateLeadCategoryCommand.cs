#region

using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.Command.CreateLeadCategory;
public record CreateLeadCategoryCommand(CreateLeadCategoryRequest LeadCategory) : IRequest<ServerResponse>;