#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Query.GetAllJobApplicationCategory;
internal class GetAllJobApplicationCategoryQueryHandler(
    IJobApplicationCategory _jobApplicationCategoryRepository,
    IMapper mapper) : IRequestHandler<GetAllJobApplicationCategoryQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllJobApplicationCategoryQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.JobApplicationCategory>? jobApplicationCategory = await _jobApplicationCategoryRepository.GetAllAsync();
        if (jobApplicationCategory is null)
        {
            return new ServerResponse(Message: "No Job Application Category Found");
        }

        // Map the plan types to the response
        IEnumerable<GetJobApplicationCategory>? leadSourcResponse = mapper.Map<IEnumerable<GetJobApplicationCategory>>(jobApplicationCategory);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Job Application Category Not Found");
        }

        return new ServerResponse(true, "List of Job Application Categories", leadSourcResponse);
    }
}