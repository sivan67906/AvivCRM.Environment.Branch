using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Query.GetDatePatternById;

internal class GetDatePatternByIdQueryHandler(IDatePattern datePatternRepository, IMapper mapper) : IRequestHandler<GetDatePatternByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetDatePatternByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the DatePattern by id
        Domain.Entities.DatePattern? datePattern = await datePatternRepository.GetByIdAsync(request.Id);
        if (datePattern is null) return new ServerResponse(Message: "DatePattern Not Found");

        // Map the entity to the response
        GetDatePattern? datePatternResponse = mapper.Map<GetDatePattern>(datePattern); // <DTO> (parameter)
        if (datePatternResponse is null) return new ServerResponse(Message: "DatePattern Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of DatePattern", Data: datePatternResponse);
    }
}






















