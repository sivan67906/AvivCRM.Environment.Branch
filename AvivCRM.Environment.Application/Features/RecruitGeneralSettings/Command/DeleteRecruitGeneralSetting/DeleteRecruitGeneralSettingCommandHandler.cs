#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Command.DeleteRecruitGeneralSetting;
internal class DeleteRecruitGeneralSettingCommandHandler(
    IRecruitGeneralSetting _recruitGeneralSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitGeneralSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitGeneralSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        RecruitGeneralSetting? recruitGeneralSetting = await _recruitGeneralSettingRepository.GetByIdAsync(request.Id);
        if (recruitGeneralSetting is null)
        {
            return new ServerResponse(Message: "Recruit General Setting Not Found");
        }

        // Map the request to the entity
        RecruitGeneralSetting delMapEntity = mapper.Map<RecruitGeneralSetting>(recruitGeneralSetting);

        try
        {
            // Delete plan type
            _recruitGeneralSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit General Setting deleted successfully", delMapEntity);
    }
}