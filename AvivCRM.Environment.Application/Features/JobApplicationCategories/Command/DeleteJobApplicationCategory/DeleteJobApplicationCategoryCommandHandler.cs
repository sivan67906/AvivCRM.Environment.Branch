#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.DeleteJobApplicationCategory;
internal class DeleteJobApplicationCategoryCommandHandler(
    IJobApplicationCategory _jobApplicationCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteJobApplicationCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteJobApplicationCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        JobApplicationCategory? jobApplicationCategory = await _jobApplicationCategoryRepository.GetByIdAsync(request.Id);
        if (jobApplicationCategory is null)
        {
            return new ServerResponse(Message: "Job Application Category Not Found");
        }

        // Map the request to the entity
        JobApplicationCategory delMapEntity = mapper.Map<JobApplicationCategory>(jobApplicationCategory);

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

        return new ServerResponse(true, "Job Application Category deleted successfully", jobApplicationCategory);
    }
}