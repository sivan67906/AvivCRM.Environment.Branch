#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Query.GetPlanningById;
internal class GetPlanningByIdQueryHandler(IPlanning planTypeRepository, IMapper mapper)
    : IRequestHandler<GetPlanningByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPlanningByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the planning by id
        Domain.Entities.Planning? planning = await planTypeRepository.GetByIdAsync(request.Id);
        if (planning is null)
        {
            return new ServerResponse(Message: "Planning Not Found");
        }

        // Map the entity to the response
        GetPlanning? planningResponse = mapper.Map<GetPlanning>(planning);
        if (planningResponse is null)
        {
            return new ServerResponse(Message: "Planning Not Found");
        }

        return new ServerResponse(true, "List of Planning", planningResponse);
    }
}