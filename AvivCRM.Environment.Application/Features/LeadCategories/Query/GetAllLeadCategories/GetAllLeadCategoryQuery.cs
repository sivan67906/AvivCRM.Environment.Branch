#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.Query.GetAllLeadCategories;
public record GetAllLeadCategoryQuery : IRequest<ServerResponse>;