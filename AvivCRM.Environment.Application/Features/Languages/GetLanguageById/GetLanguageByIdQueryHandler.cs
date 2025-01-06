using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.GetLanguageById;
internal class GetLanguageByIdQueryHandler(ILanguage planTypeRepository, IMapper mapper) : IRequestHandler<GetLanguageByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the plan type by id
        var language = await planTypeRepository.GetByIdAsync(request.Id);
        if (language is null) return new ServerResponse(Message: "Language Not Found");

        // Map the entity to the response
        var languageResponse = mapper.Map<GetLanguage>(language);
        if (languageResponse is null) return new ServerResponse(Message: "Language Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Language", Data: languageResponse);
    }
}