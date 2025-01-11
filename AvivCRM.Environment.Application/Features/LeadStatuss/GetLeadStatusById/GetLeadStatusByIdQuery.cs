#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuses.GetLeadStatusById;
public record GetLeadStatusByIdQuery(Guid Id) : IRequest<ServerResponse>;