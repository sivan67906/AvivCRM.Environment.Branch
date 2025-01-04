using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadAgents.UpdateLeadAgent;

public record UpdateLeadAgentCommand(UpdateLeadAgentRequest LeadAgent) : IRequest<ServerResponse>;


