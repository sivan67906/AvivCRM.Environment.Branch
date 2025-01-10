#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.DeleteRecruitFooterSetting;
internal class DeleteRecruitFooterSettingCommandHandler(
    IRecruitFooterSetting _recruitFooterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitFooterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitFooterSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        var recruitFooterSetting = await _recruitFooterSettingRepository.GetByIdAsync(request.Id);
        if (recruitFooterSetting is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruitFooterSetting>(recruitFooterSetting);

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