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

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.CreateJobApplicationCategory;
internal class CreateJobApplicationCategoryCommandHandler(
    IValidator<CreateJobApplicationCategoryRequest> validator,
    IJobApplicationCategory _jobApplicationCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateJobApplicationCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateJobApplicationCategoryCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.JobApplicationCategory);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        JobApplicationCategory jobApplicationCategoryEntity = mapper.Map<JobApplicationCategory>(request.JobApplicationCategory);

        try
        {
            _jobApplicationCategoryRepository.Add(jobApplicationCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Job Application Category created successfully", jobApplicationCategoryEntity);
    }
}