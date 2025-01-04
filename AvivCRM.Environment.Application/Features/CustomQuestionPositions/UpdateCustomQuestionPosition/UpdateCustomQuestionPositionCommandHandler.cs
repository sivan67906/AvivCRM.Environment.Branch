using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.UpdateCustomQuestionPosition;

internal class UpdateCustomQuestionPositionCommandHandler(IValidator<UpdateCustomQuestionPositionRequest> _validator, ICustomQuestionPosition _customQuestionPositionRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateCustomQuestionPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCustomQuestionPositionCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.CustomQuestionPosition);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var customQuestionPosition = await _customQuestionPositionRepository.GetByIdAsync(request.CustomQuestionPosition.Id);
        if (customQuestionPosition is null) return new ServerResponse(Message: "Custom Question Position Not Found");

        // Map the request to the entity
        var customQuestionPositionEntity = mapper.Map<CustomQuestionPosition>(request.CustomQuestionPosition);

        try
        {
            // Update the lead Source
            _customQuestionPositionRepository.Update(customQuestionPositionEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Position Updated Successfully", Data: customQuestionPosition);
    }
}









