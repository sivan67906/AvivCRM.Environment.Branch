#region

using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.UpdateLeadAgent;
public record UpdateLeadAgentCommand(UpdateLeadAgentRequest LeadAgent) : IRequest<ServerResponse>;