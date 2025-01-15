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

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.UpdateJobApplicationPosition;
internal class UpdateJobApplicationPositionCommandHandler(
    IValidator<UpdateJobApplicationPositionRequest> _validator,
    IJobApplicationPosition _jobApplicationPositionRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateJobApplicationPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateJobApplicationPositionCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.JobApplicationPosition);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        JobApplicationPosition? jobApplicationPosition =
            await _jobApplicationPositionRepository.GetByIdAsync(request.JobApplicationPosition.Id);
        if (jobApplicationPosition is null)
        {
            return new ServerResponse(Message: "Job Application Position Not Found");
        }

        // Map the request to the entity
        JobApplicationPosition jobApplicationPositionEntity = mapper.Map<JobApplicationPosition>(request.JobApplicationPosition);

        try
        {
            // Update the lead Source
            _jobApplicationPositionRepository.Update(jobApplicationPositionEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Job Application Position updated successfully", jobApplicationPosition);
    }
}