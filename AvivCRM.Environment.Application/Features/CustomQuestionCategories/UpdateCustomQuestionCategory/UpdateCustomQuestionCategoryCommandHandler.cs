using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.UpdateCustomQuestionCategory;

internal class UpdateCustomQuestionCategoryCommandHandler(IValidator<UpdateCustomQuestionCategoryRequest> _validator, ICustomQuestionCategory _customQuestionCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateCustomQuestionCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCustomQuestionCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.CustomQuestionCategory);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var customQuestionCategory = await _customQuestionCategoryRepository.GetByIdAsync(request.CustomQuestionCategory.Id);
        if (customQuestionCategory is null) return new ServerResponse(Message: "Custom Question Category Not Found");

        // Map the request to the entity
        var customQuestionCategoryEntity = mapper.Map<CustomQuestionCategory>(request.CustomQuestionCategory);

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

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Category updated successfully", Data: customQuestionCategory);
    }
}









