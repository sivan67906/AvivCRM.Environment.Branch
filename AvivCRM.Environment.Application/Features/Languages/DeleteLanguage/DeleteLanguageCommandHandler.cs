#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.DeleteLanguage;
internal class DeleteLanguageCommandHandler(ILanguage _languageRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteLanguageCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var language = await _languageRepository.GetByIdAsync(request.Id);
        if (language is null)
        {
            return new ServerResponse(Message: "Language Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<Language>(language);

        try
        {
            // Delete language
            _languageRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Language deleted successfully", delMapEntity);
    }
}