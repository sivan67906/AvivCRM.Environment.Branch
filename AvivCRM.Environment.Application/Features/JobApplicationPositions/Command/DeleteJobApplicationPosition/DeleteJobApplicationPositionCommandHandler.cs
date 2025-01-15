#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.DeleteJobApplicationPosition;
internal class DeleteJobApplicationPositionCommandHandler(
    IJobApplicationPosition _jobApplicationPositionRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteJobApplicationPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteJobApplicationPositionCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        JobApplicationPosition? jobApplicationPosition = await _jobApplicationPositionRepository.GetByIdAsync(request.Id);
        if (jobApplicationPosition is null)
        {
            return new ServerResponse(Message: "Job Application Position Not Found");
        }

        // Map the request to the entity
        JobApplicationPosition delMapEntity = mapper.Map<JobApplicationPosition>(jobApplicationPosition);

        try
        {
            // Delete plan type
            _jobApplicationPositionRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Job Application Position deleted successfully", jobApplicationPosition);
    }
}