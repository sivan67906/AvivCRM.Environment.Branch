#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Query.GetLeadSourceById;
internal class GetLeadSourceByIdQueryHandler(ILeadSource leadSourceRepository, IMapper mapper)
    : IRequestHandler<GetLeadSourceByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLeadSourceByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Lead Source by id
        Domain.Entities.Lead.LeadSource? leadSource = await leadSourceRepository.GetByIdAsync(request.Id);
        if (leadSource is null)
        {
            return new ServerResponse(Message: "Lead Source Not Found");
        }

        // Map the entity to the response
        GetLeadSource? leadSourceResponse = mapper.Map<GetLeadSource>(leadSource); // <DTO> (parameter)
        if (leadSourceResponse is null)
        {
            return new ServerResponse(Message: "Lead Source Not Found");
        }

        return new ServerResponse(true, "List of Lead Source", leadSourceResponse);
    }
}