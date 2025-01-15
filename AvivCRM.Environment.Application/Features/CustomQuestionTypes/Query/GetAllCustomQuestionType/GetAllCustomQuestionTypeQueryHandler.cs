#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.Query.GetAllCustomQuestionType;
internal class GetAllCustomQuestionTypeQueryHandler(ICustomQuestionType _customQuestionTypeRepository, IMapper mapper)
    : IRequestHandler<GetAllCustomQuestionTypeQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllCustomQuestionTypeQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.CustomQuestionType>? customQuestionType = await _customQuestionTypeRepository.GetAllAsync();
        if (customQuestionType is null)
        {
            return new ServerResponse(Message: "No Custom Question Type Found");
        }

        // Map the plan types to the response
        IEnumerable<GetCustomQuestionType>? leadSourcResponse = mapper.Map<IEnumerable<GetCustomQuestionType>>(customQuestionType);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Custom Question Type Not Found");
        }

        return new ServerResponse(true, "List of Custom Question Types", leadSourcResponse);
    }
}