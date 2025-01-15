#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.UpdateCustomQuestionType;
internal class UpdateCustomQuestionTypeCommandHandler(
    IValidator<UpdateCustomQuestionTypeRequest> _validator,
    ICustomQuestionType _customQuestionTypeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomQuestionTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCustomQuestionTypeCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.CustomQuestionType);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var customQuestionType = await _customQuestionTypeRepository.GetByIdAsync(request.CustomQuestionType.Id);
        if (customQuestionType is null)
        {
            return new ServerResponse(Message: "Custom Question Type Not Found");
        }

        // Map the request to the entity
        var customQuestionTypeEntity = mapper.Map<CustomQuestionType>(request.CustomQuestionType);

        try
        {
            // Update the lead Source
            _customQuestionTypeRepository.Update(customQuestionTypeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Custom Question Type updated successfully", customQuestionType);
    }
}