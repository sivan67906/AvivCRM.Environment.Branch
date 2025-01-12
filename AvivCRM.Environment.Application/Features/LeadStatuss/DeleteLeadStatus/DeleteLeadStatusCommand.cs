#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuses.DeleteLeadStatus;
public record DeleteLeadStatusCommand(Guid Id) : IRequest<ServerResponse>;