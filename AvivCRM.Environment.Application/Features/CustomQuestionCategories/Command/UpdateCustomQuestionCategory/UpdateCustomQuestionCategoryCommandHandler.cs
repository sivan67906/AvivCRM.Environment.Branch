#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.UpdateCustomQuestionCategory;
internal class UpdateCustomQuestionCategoryCommandHandler(
    IValidator<UpdateCustomQuestionCategoryRequest> _validator,
    ICustomQuestionCategory _customQuestionCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomQuestionCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCustomQuestionCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.CustomQuestionCategory);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        CustomQuestionCategory? customQuestionCategory =
            await _customQuestionCategoryRepository.GetByIdAsync(request.CustomQuestionCategory.Id);
        if (customQuestionCategory is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        // Map the request to the entity
        CustomQuestionCategory customQuestionCategoryEntity = mapper.Map<CustomQuestionCategory>(request.CustomQuestionCategory);

        try
        {
            // Update the lead Source
            _customQuestionCategoryRepository.Update(customQuestionCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Custom Question Category updated successfully", customQuestionCategory);
    }
}