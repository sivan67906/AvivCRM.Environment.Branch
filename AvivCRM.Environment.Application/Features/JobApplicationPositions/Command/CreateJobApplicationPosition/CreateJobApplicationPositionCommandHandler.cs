#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.CreateJobApplicationPosition;
internal class CreateJobApplicationPositionCommandHandler(
    IValidator<CreateJobApplicationPositionRequest> validator,
    IJobApplicationPosition _jobApplicationPositionRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateJobApplicationPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateJobApplicationPositionCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.JobApplicationPosition);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        JobApplicationPosition jobApplicationPositionEntity = mapper.Map<JobApplicationPosition>(request.JobApplicationPosition);

        try
        {
            _jobApplicationPositionRepository.Add(jobApplicationPositionEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Job Application Position created successfully", jobApplicationPositionEntity);
    }
}