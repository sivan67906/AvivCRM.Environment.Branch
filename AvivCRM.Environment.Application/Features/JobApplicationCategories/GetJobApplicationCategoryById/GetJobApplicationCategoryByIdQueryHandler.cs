#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.GetJobApplicationCategoryById;
internal class GetJobApplicationCategoryByIdQueryHandler(
    IJobApplicationCategory jobApplicationCategoryRepository,
    IMapper mapper) : IRequestHandler<GetJobApplicationCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetJobApplicationCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Job Application Category by id
        var jobApplicationCategory = await jobApplicationCategoryRepository.GetByIdAsync(request.Id);
        if (jobApplicationCategory is null)
        {
            return new ServerResponse(Message: "Job Application Category Not Found");
        }

        // Map the entity to the response
        var jobApplicationCategoryResponse =
            mapper.Map<GetJobApplicationCategory>(jobApplicationCategory); // <DTO> (parameter)
        if (jobApplicationCategoryResponse is null)
        {
            return new ServerResponse(Message: "Job Application Category Not Found");
        }

        return new ServerResponse(true, "List of Job Application Category", jobApplicationCategoryResponse);
    }
}