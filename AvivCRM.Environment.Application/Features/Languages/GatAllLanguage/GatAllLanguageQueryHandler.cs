using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.GatAllLanguage;
internal class GetAllLanguageQueryHandler(ILanguage _languageRepository, IMapper mapper) : IRequestHandler<GetAllLanguagesQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        // Get all lead agent
        var languages = await _languageRepository.GetAllAsync();
        if (languages is null) return new ServerResponse(Message: "No Language Found");

        // Map the lead agent to the response
        var languageResponse = mapper.Map<IEnumerable<GetLanguage>>(languages);
        if (languageResponse is null) return new ServerResponse(Message: "Language Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Languages", Data: languageResponse);
    }
}
