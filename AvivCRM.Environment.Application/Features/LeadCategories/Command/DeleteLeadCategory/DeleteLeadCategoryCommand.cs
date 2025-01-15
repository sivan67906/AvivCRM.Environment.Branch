#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.Command.DeleteLeadCategory;
public record DeleteLeadCategoryCommand(Guid Id) : IRequest<ServerResponse>;