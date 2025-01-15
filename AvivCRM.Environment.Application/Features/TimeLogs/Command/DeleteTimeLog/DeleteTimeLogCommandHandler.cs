#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Command.DeleteTimeLog;
internal class DeleteTimeLogCommandHandler(ITimeLog _timeLogRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteTimeLogCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTimeLogCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        TimeLog? timeLog = await _timeLogRepository.GetByIdAsync(request.Id);
        if (timeLog is null)
        {
            return new ServerResponse(Message: "TimeLog Not Found");
        }

        // Map the request to the entity
        TimeLog delMapEntity = mapper.Map<TimeLog>(timeLog);

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

        return new ServerResponse(true, "TimeLog deleted successfully", delMapEntity);
    }
}