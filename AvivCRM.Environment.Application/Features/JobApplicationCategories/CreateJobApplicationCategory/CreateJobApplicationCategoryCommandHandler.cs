using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.CreateJobApplicationCategory;

internal class CreateJobApplicationCategoryCommandHandler(IValidator<CreateJobApplicationCategoryRequest> validator,
    IJobApplicationCategory _jobApplicationCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateJobApplicationCategoryCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateJobApplicationCategoryCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.JobApplicationCategory);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var jobApplicationCategoryEntity = mapper.Map<JobApplicationCategory>(request.JobApplicationCategory);

        try
        {
            _jobApplicationCategoryRepository.Add(jobApplicationCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Job Application Category Created Succcessfully", Data: jobApplicationCategoryEntity);
    }
}











