using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.DeleteJobApplicationCategory;

internal class DeleteJobApplicationCategoryCommandHandler(IJobApplicationCategory _jobApplicationCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteJobApplicationCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteJobApplicationCategoryCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var jobApplicationCategory = await _jobApplicationCategoryRepository.GetByIdAsync(request.Id);
        if (jobApplicationCategory is null) return new ServerResponse(Message: "Job Application Category Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<JobApplicationCategory>(jobApplicationCategory);

        try
        {
            // Delete plan type
            _jobApplicationCategoryRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Job Application Category deleted successfully", Data: jobApplicationCategory);
    }
}











