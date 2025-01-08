#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.GetAllLeadAgents;
internal class GetAllLeadAgentQueryHandler(ILeadAgent _leadAgentRepository, IMapper mapper)
    : IRequestHandler<GetAllLeadAgentsQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLeadAgentsQuery request, CancellationToken cancellationToken)
    {
        // Get all lead agent
        var leadAgents = await _leadAgentRepository.GetAllAsync();
        if (leadAgents is null)
        {
            return new ServerResponse(Message: "No Lead Agent Found");
        }

        // Map the lead agent to the response
        var leadAgentResponse = mapper.Map<IEnumerable<GetLeadAgent>>(leadAgents);
        if (leadAgentResponse is null)
        {
            return new ServerResponse(Message: "Lead Agent Not Found");
        }

        return new ServerResponse(true, "List of Lead Agents", leadAgentResponse);
    }
}