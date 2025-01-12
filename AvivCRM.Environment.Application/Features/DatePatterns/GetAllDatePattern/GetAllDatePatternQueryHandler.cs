using AutoMapper;
using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Application.Features.DatePatterns.GetAllDatePattern;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.GetAllDatePattern;
internal class GetAllDatePatternQueryHandler(IDatePattern _datePatternRepository, IMapper mapper) : IRequestHandler<GetAllDatePatternQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllDatePatternQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var datePattern = await _datePatternRepository.GetAllAsync();
        if (datePattern is null) return new ServerResponse(Message: "No DatePattern Found");

        // Map the plan types to the response
        var datePatternResponse = mapper.Map<IEnumerable<GetDatePattern>>(datePattern);
        if (datePatternResponse is null) return new ServerResponse(Message: "DatePattern Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of DatePatterns", Data: datePatternResponse);
    }
}
























