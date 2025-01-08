#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.GetLeadCategoryById;
public record GetLeadCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;