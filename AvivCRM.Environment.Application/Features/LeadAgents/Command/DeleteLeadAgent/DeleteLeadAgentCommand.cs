#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.DeleteLeadAgent;
public record DeleteLeadAgentCommand(Guid Id) : IRequest<ServerResponse>;