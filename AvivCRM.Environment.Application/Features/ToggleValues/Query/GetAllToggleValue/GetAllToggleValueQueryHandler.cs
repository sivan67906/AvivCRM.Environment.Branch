using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Query.GetAllToggleValue;
internal class GetAllToggleValueQueryHandler(IToggleValue _toggleValueRepository, IMapper mapper) : IRequestHandler<GetAllToggleValueQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllToggleValueQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.ToggleValue>? toggleValue = await _toggleValueRepository.GetAllAsync();
        if (toggleValue is null) return new ServerResponse(Message: "No Toggle Value Found");

        // Map the plan types to the response
        IEnumerable<GetToggleValue>? toggleValueResponse = mapper.Map<IEnumerable<GetToggleValue>>(toggleValue);
        if (toggleValueResponse is null) return new ServerResponse(Message: "Toggle Value Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Toggle Values", Data: toggleValueResponse);
    }
}










































