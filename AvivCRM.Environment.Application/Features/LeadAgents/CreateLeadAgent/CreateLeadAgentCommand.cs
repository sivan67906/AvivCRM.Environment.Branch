using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadAgents.CreateLeadAgent
{
    public record CreateLeadAgentCommand(CreateLeadAgentRequest LeadAgent) : IRequest<ServerResponse>;
}


