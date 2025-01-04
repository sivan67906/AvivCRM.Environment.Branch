using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.GetAllJobApplicationCategory;
internal class GetAllJobApplicationCategoryQueryHandler(IJobApplicationCategory _jobApplicationCategoryRepository, IMapper mapper) : IRequestHandler<GetAllJobApplicationCategoryQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllJobApplicationCategoryQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var jobApplicationCategory = await _jobApplicationCategoryRepository.GetAllAsync();
        if (jobApplicationCategory is null) return new ServerResponse(Message: "No Job Application Category Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetJobApplicationCategory>>(jobApplicationCategory);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Job Application Category Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Job Application Categories", Data: leadSourcResponse);
    }
}











