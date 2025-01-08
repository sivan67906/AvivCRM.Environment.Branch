#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.CreateCustomQuestionType;
internal class CreateCustomQuestionTypeCommandHandler(
    IValidator<CreateCustomQuestionTypeRequest> validator,
    ICustomQuestionType _customQuestionTypeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateCustomQuestionTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateCustomQuestionTypeCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.CustomQuestionType);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var customQuestionTypeEntity = mapper.Map<CustomQuestionType>(request.CustomQuestionType);

        try
        {
            _customQuestionTypeRepository.Add(customQuestionTypeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Custom Question Type created successfully", customQuestionTypeEntity);
    }
}