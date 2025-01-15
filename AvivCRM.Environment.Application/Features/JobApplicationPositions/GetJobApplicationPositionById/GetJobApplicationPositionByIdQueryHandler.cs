#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.GetJobApplicationPositionById;
internal class GetJobApplicationPositionByIdQueryHandler(
    IJobApplicationPosition jobApplicationPositionRepository,
    IMapper mapper) : IRequestHandler<GetJobApplicationPositionByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetJobApplicationPositionByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Job Application Position by id
        var jobApplicationPosition = await jobApplicationPositionRepository.GetByIdAsync(request.Id);
        if (jobApplicationPosition is null)
        {
            return new ServerResponse(Message: "Job Application Position Not Found");
        }

        // Map the entity to the response
        var jobApplicationPositionResponse =
            mapper.Map<GetJobApplicationPosition>(jobApplicationPosition); // <DTO> (parameter)
        if (jobApplicationPositionResponse is null)
        {
            return new ServerResponse(Message: "Job Application Position Not Found");
        }

        return new ServerResponse(true, "List of Job Application Position", jobApplicationPositionResponse);
    }
}