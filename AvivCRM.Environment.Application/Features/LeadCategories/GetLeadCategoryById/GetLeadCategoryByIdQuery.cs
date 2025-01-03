using MediatR;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadCategories.GetLeadCategoryById;

public record GetLeadCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;