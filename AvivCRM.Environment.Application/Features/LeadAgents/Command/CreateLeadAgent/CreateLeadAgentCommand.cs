#region

using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.CreateLeadAgent;
public record CreateLeadAgentCommand(CreateLeadAgentRequest LeadAgent) : IRequest<ServerResponse>;