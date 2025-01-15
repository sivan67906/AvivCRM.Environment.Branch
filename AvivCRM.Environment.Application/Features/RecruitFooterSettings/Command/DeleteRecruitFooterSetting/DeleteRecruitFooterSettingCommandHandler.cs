#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.DeleteRecruitFooterSetting;
internal class DeleteRecruitFooterSettingCommandHandler(
    IRecruitFooterSetting _recruitFooterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitFooterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitFooterSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        RecruitFooterSetting? recruitFooterSetting = await _recruitFooterSettingRepository.GetByIdAsync(request.Id);
        if (recruitFooterSetting is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        // Map the request to the entity
        RecruitFooterSetting delMapEntity = mapper.Map<RecruitFooterSetting>(recruitFooterSetting);

        try
        {
            // Delete plan type
            _recruitFooterSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit Footer Setting deleted successfully", delMapEntity);
    }
}