#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.UpdateJobApplicationCategory;
internal class UpdateJobApplicationCategoryCommandHandler(
    IValidator<UpdateJobApplicationCategoryRequest> _validator,
    IJobApplicationCategory _jobApplicationCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateJobApplicationCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateJobApplicationCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.JobApplicationCategory);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        JobApplicationCategory? jobApplicationCategory =
            await _jobApplicationCategoryRepository.GetByIdAsync(request.JobApplicationCategory.Id);
        if (jobApplicationCategory is null)
        {
            return new ServerResponse(Message: "Job Application Category Not Found");
        }

        // Map the request to the entity
        JobApplicationCategory jobApplicationCategoryEntity = mapper.Map<JobApplicationCategory>(request.JobApplicationCategory);

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

        return new ServerResponse(true, "Job Application Category updated successfully", jobApplicationCategory);
    }
}