using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Application.Features.ToggleValues.GetAllToggleValue;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.GetAllToggleValue;
internal class GetAllToggleValueQueryHandler(IToggleValue _toggleValueRepository, IMapper mapper) : IRequestHandler<GetAllToggleValueQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllToggleValueQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var toggleValue = await _toggleValueRepository.GetAllAsync();
        if (toggleValue is null) return new ServerResponse(Message: "No Toggle Value Found");

        // Map the plan types to the response
        var toggleValueResponse = mapper.Map<IEnumerable<GetToggleValue>>(toggleValue);
        if (toggleValueResponse is null) return new ServerResponse(Message: "Toggle Value Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Toggle Values", Data: toggleValueResponse);
    }
}










































