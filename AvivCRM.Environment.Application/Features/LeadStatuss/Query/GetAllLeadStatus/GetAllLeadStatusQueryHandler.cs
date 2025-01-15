#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Query.GetAllLeadStatus;
internal class GetAllLeadStatusQueryHandler(ILeadStatus _leadStatusRepository, IMapper mapper)
    : IRequestHandler<GetAllLeadStatusQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLeadStatusQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Lead.LeadStatus>? leadStatus = await _leadStatusRepository.GetAllAsync();
        if (leadStatus is null)
        {
            return new ServerResponse(Message: "No Lead Status Found");
        }

        // Map the plan types to the response
        IEnumerable<GetLeadStatus>? leadStatusResponse = mapper.Map<IEnumerable<GetLeadStatus>>(leadStatus);
        if (leadStatusResponse is null)
        {
            return new ServerResponse(Message: "Lead Status Not Found");
        }

        return new ServerResponse(true, "List of Lead Statuses", leadStatusResponse);
    }
}