#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetCustomQuestionTypeById;
internal class GetCustomQuestionTypeByIdQueryHandler(ICustomQuestionType customQuestionTypeRepository, IMapper mapper)
    : IRequestHandler<GetCustomQuestionTypeByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetCustomQuestionTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Custom Question Type by id
        var customQuestionType = await customQuestionTypeRepository.GetByIdAsync(request.Id);
        if (customQuestionType is null)
        {
            return new ServerResponse(Message: "Custom Question Type Not Found");
        }

        // Map the entity to the response
        var customQuestionTypeResponse = mapper.Map<GetCustomQuestionType>(customQuestionType); // <DTO> (parameter)
        if (customQuestionTypeResponse is null)
        {
            return new ServerResponse(Message: "Custom Question Type Not Found");
        }

        return new ServerResponse(true, "List of Custom Question Type", customQuestionTypeResponse);
    }
}