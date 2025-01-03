using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.UpdateJobApplicationCategory;

internal class UpdateJobApplicationCategoryCommandHandler(IValidator<UpdateJobApplicationCategoryRequest> _validator, IJobApplicationCategory _jobApplicationCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateJobApplicationCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateJobApplicationCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.JobApplicationCategory);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var jobApplicationCategory = await _jobApplicationCategoryRepository.GetByIdAsync(request.JobApplicationCategory.Id);
        if (jobApplicationCategory is null) return new ServerResponse(Message: "Job Application Category Not Found");

        // Map the request to the entity
        var jobApplicationCategoryEntity = mapper.Map<JobApplicationCategory>(request.JobApplicationCategory);

        try
        {
            // Update the lead Source
            _jobApplicationCategoryRepository.Update(jobApplicationCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Job Application Category Updated Successfully", Data: jobApplicationCategory);
    }
}









