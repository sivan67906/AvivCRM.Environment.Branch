#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.DeleteLeadCategory;
public record DeleteLeadCategoryCommand(Guid Id) : IRequest<ServerResponse>;