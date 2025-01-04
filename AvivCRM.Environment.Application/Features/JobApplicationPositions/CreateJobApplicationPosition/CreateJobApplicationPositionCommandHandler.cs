using AutoMapper;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.CreateJobApplicationPosition;

internal class CreateJobApplicationPositionCommandHandler(IValidator<CreateJobApplicationPositionRequest> validator,
    IJobApplicationPosition _jobApplicationPositionRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateJobApplicationPositionCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateJobApplicationPositionCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.JobApplicationPosition);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var jobApplicationPositionEntity = mapper.Map<JobApplicationPosition>(request.JobApplicationPosition);

        try
        {
            _jobApplicationPositionRepository.Add(jobApplicationPositionEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Job Application Position created successfully", Data: jobApplicationPositionEntity);
    }
}



















