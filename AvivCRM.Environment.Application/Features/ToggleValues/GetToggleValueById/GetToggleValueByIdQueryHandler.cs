using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.GetToggleValueById;

internal class GetToggleValueByIdQueryHandler(IToggleValue toggleValueRepository, IMapper mapper) : IRequestHandler<GetToggleValueByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetToggleValueByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Toggle Value by id
        var toggleValue = await toggleValueRepository.GetByIdAsync(request.Id);
        if (toggleValue is null) return new ServerResponse(Message: "Toggle Value Not Found");

        // Map the entity to the response
        var toggleValueResponse = mapper.Map<GetToggleValue>(toggleValue); // <DTO> (parameter)
        if (toggleValueResponse is null) return new ServerResponse(Message: "Toggle Value Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Toggle Value", Data: toggleValueResponse);
    }
}








































