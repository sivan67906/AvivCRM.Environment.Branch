#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Query.GetLanguageById;
internal class GetLanguageByIdQueryHandler(ILanguage planTypeRepository, IMapper mapper)
    : IRequestHandler<GetLanguageByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the plan type by id
        Domain.Entities.Language? language = await planTypeRepository.GetByIdAsync(request.Id);
        if (language is null)
        {
            return new ServerResponse(Message: "Language Not Found");
        }

        // Map the entity to the response
        GetLanguage? languageResponse = mapper.Map<GetLanguage>(language);
        if (languageResponse is null)
        {
            return new ServerResponse(Message: "Language Not Found");
        }

        return new ServerResponse(true, "List of Language", languageResponse);
    }
}