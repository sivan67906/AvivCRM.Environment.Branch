#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.DeleteRecruitJobApplicationStatusSetting;
internal class DeleteRecruitJobApplicationStatusSettingCommandHandler(
    IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitJobApplicationStatusSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitJobApplicationStatusSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        RecruitJobApplicationStatusSetting? recruitJobApplicationStatusSetting =
            await _recruitJobApplicationStatusSettingRepository.GetByIdAsync(request.Id);
        if (recruitJobApplicationStatusSetting is null)
        {
            return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");
        }

        // Map the request to the entity
        RecruitJobApplicationStatusSetting delMapEntity = mapper.Map<RecruitJobApplicationStatusSetting>(recruitJobApplicationStatusSetting);

        try
        {
            // Delete plan type
            _recruitJobApplicationStatusSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit JobApplication Status Setting deleted successfully",
            delMapEntity);
    }
}