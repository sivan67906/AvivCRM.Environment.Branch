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

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.CreateCustomQuestionCategory;
internal class CreateCustomQuestionCategoryCommandHandler(
    IValidator<CreateCustomQuestionCategoryRequest> validator,
    ICustomQuestionCategory _customQuestionCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateCustomQuestionCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateCustomQuestionCategoryCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.CustomQuestionCategory);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        CustomQuestionCategory customQuestionCategoryEntity = mapper.Map<CustomQuestionCategory>(request.CustomQuestionCategory);

        try
        {
            _customQuestionCategoryRepository.Add(customQuestionCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Custom Question Category created successfully", customQuestionCategoryEntity);
    }
}