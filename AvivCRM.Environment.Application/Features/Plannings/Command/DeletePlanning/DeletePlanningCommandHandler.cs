#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Command.DeletePlanning;
internal class DeletePlanningCommandHandler(IPlanning _planningRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeletePlanningCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeletePlanningCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Planning? planning = await _planningRepository.GetByIdAsync(request.Id);
        if (planning is null)
        {
            return new ServerResponse(Message: "Planning Not Found");
        }

        // Map the request to the entity
        Planning delMapEntity = mapper.Map<Planning>(planning);

        try
        {
            // Delete Planning
            _planningRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Planning deleted successfully", delMapEntity);
    }
}