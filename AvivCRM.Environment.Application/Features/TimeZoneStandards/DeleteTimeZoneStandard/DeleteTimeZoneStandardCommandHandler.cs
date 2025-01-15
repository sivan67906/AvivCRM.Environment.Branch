using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.DeleteTimeZoneStandard;

internal class DeleteTimeZoneStandardCommandHandler(ITimeZoneStandard _timeZoneStandardRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTimeZoneStandardCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTimeZoneStandardCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var timeZoneStandard = await _timeZoneStandardRepository.GetByIdAsync(request.Id);
        if (timeZoneStandard is null) return new ServerResponse(Message: "TimeZone Standard Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<TimeZoneStandard>(timeZoneStandard);

        try
        {
            // Delete TimeZone Standard
            _timeZoneStandardRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "TimeZone Standard deleted successfully", Data: delMapEntity);
    }
}
























