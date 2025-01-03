using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.GetAllLeadStatus;
internal class GetAllLeadStatusQueryHandler(ILeadStatus _leadStatusRepository, IMapper mapper) : IRequestHandler<GetAllLeadStatusQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLeadStatusQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var leadStatus = await _leadStatusRepository.GetAllAsync();
        if (leadStatus is null) return new ServerResponse(Message: "No Lead Status Found");

        // Map the plan types to the response
        var leadStatusResponse = mapper.Map<IEnumerable<GetLeadStatus>>(leadStatus);
        if (leadStatusResponse is null) return new ServerResponse(Message: "Lead Status Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Lead Status", Data: leadStatusResponse);
    }
}
