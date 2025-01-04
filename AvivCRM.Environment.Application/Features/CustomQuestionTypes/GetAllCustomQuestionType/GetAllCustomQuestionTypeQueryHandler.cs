using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetAllCustomQuestionType;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetAllCustomQuestionType;
internal class GetAllCustomQuestionTypeQueryHandler(ICustomQuestionType _customQuestionTypeRepository, IMapper mapper) : IRequestHandler<GetAllCustomQuestionTypeQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllCustomQuestionTypeQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var customQuestionType = await _customQuestionTypeRepository.GetAllAsync();
        if (customQuestionType is null) return new ServerResponse(Message: "No Custom Question Type Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetCustomQuestionType>>(customQuestionType);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Custom Question Type Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Custom Question Type", Data: leadSourcResponse);
    }
}











