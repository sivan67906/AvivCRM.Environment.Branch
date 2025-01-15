#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Query.GetAllLanguage;
internal class GetAllLanguageQueryHandler(ILanguage _languageRepository, IMapper mapper)
    : IRequestHandler<GetAllLanguagesQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        // Get all lead agent
        IEnumerable<Domain.Entities.Language>? languages = await _languageRepository.GetAllAsync();
        if (languages is null)
        {
            return new ServerResponse(Message: "No Language Found");
        }

        // Map the lead agent to the response
        IEnumerable<GetLanguage>? languageResponse = mapper.Map<IEnumerable<GetLanguage>>(languages);
        if (languageResponse is null)
        {
            return new ServerResponse(Message: "Language Not Found");
        }

        return new ServerResponse(true, "List of Languages", languageResponse);
    }
}