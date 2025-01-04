using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.GetPlanningById;
internal class GetPlanningByIdQueryHandler(IPlanning planTypeRepository, IMapper mapper) : IRequestHandler<GetPlanningByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPlanningByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the planning by id
        var planning = await planTypeRepository.GetByIdAsync(request.Id);
        if (planning is null) return new ServerResponse(Message: "Planning Not Found");

        // Map the entity to the response
        var planningResponse = mapper.Map<GetPlanning>(planning);
        if (planningResponse is null) return new ServerResponse(Message: "Planning Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Planning", Data: planningResponse);
    }
}