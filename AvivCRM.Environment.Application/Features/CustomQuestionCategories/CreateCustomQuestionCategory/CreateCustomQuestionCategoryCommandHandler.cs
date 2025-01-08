#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.CreateCustomQuestionCategory;
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
        var validate = await validator.ValidateAsync(request.CustomQuestionCategory);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var customQuestionCategoryEntity = mapper.Map<CustomQuestionCategory>(request.CustomQuestionCategory);

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