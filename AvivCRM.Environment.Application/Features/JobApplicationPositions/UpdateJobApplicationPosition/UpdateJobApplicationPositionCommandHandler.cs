using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.UpdateJobApplicationPosition;

internal class UpdateJobApplicationPositionCommandHandler(IValidator<UpdateJobApplicationPositionRequest> _validator, IJobApplicationPosition _jobApplicationPositionRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateJobApplicationPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateJobApplicationPositionCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.JobApplicationPosition);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var jobApplicationPosition = await _jobApplicationPositionRepository.GetByIdAsync(request.JobApplicationPosition.Id);
        if (jobApplicationPosition is null) return new ServerResponse(Message: "Job Application Position Not Found");

        // Map the request to the entity
        var jobApplicationPositionEntity = mapper.Map<JobApplicationPosition>(request.JobApplicationPosition);

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

        return new ServerResponse(IsSuccess: true, Message: "Job Application Position Updated Successfully", Data: jobApplicationPosition);
    }
}

















