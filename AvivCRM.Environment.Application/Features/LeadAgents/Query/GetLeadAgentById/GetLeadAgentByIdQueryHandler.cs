#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Query.GetLeadAgentById;
internal class GetLeadAgentByIdQueryHandler(ILeadAgent planTypeRepository, IMapper mapper)
    : IRequestHandler<GetLeadAgentByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLeadAgentByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the plan type by id
        Domain.Entities.Lead.LeadAgent? leadAgent = await planTypeRepository.GetByIdAsync(request.Id);
        if (leadAgent is null)
        {
            return new ServerResponse(Message: "Lead Agent Not Found");
        }

        // Map the entity to the response
        GetLeadAgent? leadAgentResponse = mapper.Map<GetLeadAgent>(leadAgent);
        if (leadAgentResponse is null)
        {
            return new ServerResponse(Message: "Lead Agent Not Found");
        }

        return new ServerResponse(true, "List of Lead Agent", leadAgentResponse);
    }
}