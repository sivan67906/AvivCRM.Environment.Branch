using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadSources.GetLeadSourceById;

internal class GetLeadSourceByIdQueryHandler(ILeadSource leadSourceRepository, IMapper mapper) : IRequestHandler<GetLeadSourceByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLeadSourceByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Lead Source by id
        var leadSource = await leadSourceRepository.GetByIdAsync(request.Id);
        if (leadSource is null) return new ServerResponse(Message: "Lead Source Not Found");

        // Map the entity to the response
        var leadSourceResponse = mapper.Map<GetLeadSource>(leadSource); // <DTO> (parameter)
        if (leadSourceResponse is null) return new ServerResponse(Message: "Lead Source Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Lead Source", Data: leadSourceResponse);
    }
}