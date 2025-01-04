using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeLogs.DeleteTimeLog;

internal class DeleteTimeLogCommandHandler(ITimeLog _timeLogRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTimeLogCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTimeLogCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var timeLog = await _timeLogRepository.GetByIdAsync(request.Id);
        if (timeLog is null) return new ServerResponse(Message: "TimeLog Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<TimeLog>(timeLog);

        try
        {
            // Delete plan type
            _timeLogRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "TimeLog deleted successfully", Data: timeLog);
    }
}











