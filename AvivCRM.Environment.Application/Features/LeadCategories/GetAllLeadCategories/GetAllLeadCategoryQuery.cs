#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.GetAllLeadCategories;
public record GetAllLeadCategoryQuery : IRequest<ServerResponse>;