#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Command.DeleteRecruiterSetting;
internal class DeleteRecruiterSettingCommandHandler(
    IRecruiterSetting _recruiterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruiterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruiterSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        RecruiterSetting? recruiterSetting = await _recruiterSettingRepository.GetByIdAsync(request.Id);
        if (recruiterSetting is null)
        {
            return new ServerResponse(Message: "Recruiter Setting Not Found");
        }

        // Map the request to the entity
        RecruiterSetting delMapEntity = mapper.Map<RecruiterSetting>(recruiterSetting);

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

        return new ServerResponse(true, "Recruiter Setting deleted successfully", delMapEntity);
    }
}