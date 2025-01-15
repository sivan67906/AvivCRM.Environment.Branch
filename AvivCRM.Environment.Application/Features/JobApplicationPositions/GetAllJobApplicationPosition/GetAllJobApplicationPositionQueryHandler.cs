#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.GetAllJobApplicationPosition;
internal class GetAllJobApplicationPositionQueryHandler(
    IJobApplicationPosition _jobApplicationPositionRepository,
    IMapper mapper) : IRequestHandler<GetAllJobApplicationPositionQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllJobApplicationPositionQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        var jobApplicationPosition = await _jobApplicationPositionRepository.GetAllAsync();
        if (jobApplicationPosition is null)
        {
            return new ServerResponse(Message: "No Job Application Position Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetJobApplicationPosition>>(jobApplicationPosition);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Job Application Position Not Found");
        }

        return new ServerResponse(true, "List of Job Application Positions", leadSourcResponse);
    }
}