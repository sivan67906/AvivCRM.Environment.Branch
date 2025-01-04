using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetCustomQuestionPositionById;

internal class GetCustomQuestionPositionByIdQueryHandler(ICustomQuestionPosition customQuestionPositionRepository, IMapper mapper) : IRequestHandler<GetCustomQuestionPositionByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetCustomQuestionPositionByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Custom Question Position by id
        var customQuestionPosition = await customQuestionPositionRepository.GetByIdAsync(request.Id);
        if (customQuestionPosition is null) return new ServerResponse(Message: "Custom Question Position Not Found");

        // Map the entity to the response
        var customQuestionPositionResponse = mapper.Map<GetCustomQuestionPosition>(customQuestionPosition); // <DTO> (parameter)
        if (customQuestionPositionResponse is null) return new ServerResponse(Message: "Custom Question Position Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Position", Data: customQuestionPositionResponse);
    }
}









