using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.DeleteRecruiterSetting;

internal class DeleteRecruiterSettingCommandHandler(IRecruiterSetting _recruiterSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteRecruiterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruiterSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var recruiterSetting = await _recruiterSettingRepository.GetByIdAsync(request.Id);
        if (recruiterSetting is null) return new ServerResponse(Message: "Recruiter Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruiterSetting>(recruiterSetting);

        try
        {
            // Delete plan type
            _recruiterSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Recruiter Setting deleted successfully", Data: recruiterSetting);
    }
}











