#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Command.DeleteLeadStatus;
public record DeleteLeadStatusCommand(Guid Id) : IRequest<ServerResponse>;