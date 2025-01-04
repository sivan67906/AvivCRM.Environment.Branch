using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetAllCustomQuestionPosition;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.GetAllCustomQuestionPosition;
internal class GetAllCustomQuestionPositionQueryHandler(ICustomQuestionPosition _customQuestionPositionRepository, IMapper mapper) : IRequestHandler<GetAllCustomQuestionPositionQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllCustomQuestionPositionQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var customQuestionPosition = await _customQuestionPositionRepository.GetAllAsync();
        if (customQuestionPosition is null) return new ServerResponse(Message: "No Custom Question Position Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetCustomQuestionPosition>>(customQuestionPosition);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Custom Question Position Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Custom Question Position", Data: leadSourcResponse);
    }
}











