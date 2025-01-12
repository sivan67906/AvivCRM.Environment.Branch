#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuses.GetLeadStatusById;
internal class GetLeadStatusByIdQueryHandler(ILeadStatus leadStatusRepository, IMapper mapper)
    : IRequestHandler<GetLeadStatusByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLeadStatusByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Lead Status by id
        var leadStatus = await leadStatusRepository.GetByIdAsync(request.Id);
        if (leadStatus is null)
        {
            return new ServerResponse(Message: "Lead Status Not Found");
        }

        // Map the entity to the response
        var leadStatusResponse = mapper.Map<GetLeadStatus>(leadStatus); // <DTO> (parameter)
        if (leadStatusResponse is null)
        {
            return new ServerResponse(Message: "Lead Status Not Found");
        }

        return new ServerResponse(true, "List of Lead Status", leadStatusResponse);
    }
}