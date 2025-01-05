using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.GetAllPlanning;
internal class GetAllPlanningQueryHandler(IPlanning _planningRepository, IMapper mapper) : IRequestHandler<GetAllPlanningQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPlanningQuery request, CancellationToken cancellationToken)
    {
        // Get all plannings
        var plannings = await _planningRepository.GetAllAsync();
        if (plannings is null) return new ServerResponse(Message: "No Planning Found");

        // Map the plannings to the response
        var planningResponse = mapper.Map<IEnumerable<GetPlanning>>(plannings);
        if (planningResponse is null) return new ServerResponse(Message: "Planning Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Plannings", Data: planningResponse);
    }
}