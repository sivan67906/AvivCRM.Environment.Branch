#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Query.GetAllLeadSource;
internal class GetAllLeadSourceQueryHandler(ILeadSource _leadSourceRepository, IMapper mapper)
    : IRequestHandler<GetAllLeadSourceQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLeadSourceQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Lead.LeadSource>? leadSource = await _leadSourceRepository.GetAllAsync();
        if (leadSource is null)
        {
            return new ServerResponse(Message: "No Lead Source Found");
        }

        // Map the plan types to the response
        IEnumerable<GetLeadSource>? leadSourceResponse = mapper.Map<IEnumerable<GetLeadSource>>(leadSource);
        if (leadSourceResponse is null)
        {
            return new ServerResponse(Message: "Lead Source Not Found");
        }

        return new ServerResponse(true, "List of Lead Sources", leadSourceResponse);
    }
}