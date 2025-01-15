#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Query.GetAllPlanning;
internal class GetAllPlanningQueryHandler(IPlanning _planningRepository, IMapper mapper)
    : IRequestHandler<GetAllPlanningQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPlanningQuery request, CancellationToken cancellationToken)
    {
        // Get all plannings
        IEnumerable<Domain.Entities.Planning>? plannings = await _planningRepository.GetAllAsync();
        if (plannings is null)
        {
            return new ServerResponse(Message: "No Planning Found");
        }

        // Map the plannings to the response
        IEnumerable<GetPlanning>? planningResponse = mapper.Map<IEnumerable<GetPlanning>>(plannings);
        if (planningResponse is null)
        {
            return new ServerResponse(Message: "Planning Not Found");
        }

        return new ServerResponse(true, "List of Plannings", planningResponse);
    }
}