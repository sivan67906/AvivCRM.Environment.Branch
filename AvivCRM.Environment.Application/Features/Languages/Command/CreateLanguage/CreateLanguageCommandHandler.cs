#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Command.CreateLanguage;
internal class CreateLanguageCommandHandler(
    IValidator<createLanguageRequest> _validator,
    ILanguage _languageRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateLanguageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Language);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Language already exists
        bool isAvailable = await _languageRepository.IsAvailableByNameAsync(request.Language.LanguageName!);
        if (isAvailable)
        {
            return new ServerResponse(Message: "Language Already Exists");
        }

        // Map the request to the entity
        Language languageEntity = mapper.Map<Language>(request.Language);

        try
        {
            // Add the Language
            _languageRepository.Add(languageEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Language created successfully", languageEntity);
    }
}