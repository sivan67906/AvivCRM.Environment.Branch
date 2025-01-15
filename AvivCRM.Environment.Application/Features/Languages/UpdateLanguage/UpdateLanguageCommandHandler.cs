#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.UpdateLanguage;
internal class UpdateLanguageCommandHandler(
    IValidator<UpdateLanguageRequest> _validator,
    ILanguage _languageRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateLanguageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Language);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Language exists
        var language = await _languageRepository.GetByIdAsync(request.Language.Id);
        if (language is null)
        {
            return new ServerResponse(Message: "Language Not Found");
        }

        // Map the request to the entity
        var languageEntity = mapper.Map<Language>(request.Language);

        try
        {
            // Update the Language
            _languageRepository.Update(languageEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Language updated successfully", languageEntity);
    }
}