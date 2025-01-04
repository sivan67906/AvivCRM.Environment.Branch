using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.DeleteRecruitGeneralSetting;

internal class DeleteRecruitGeneralSettingCommandHandler(IRecruitGeneralSetting _recruitGeneralSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteRecruitGeneralSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitGeneralSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var recruitGeneralSetting = await _recruitGeneralSettingRepository.GetByIdAsync(request.Id);
        if (recruitGeneralSetting is null) return new ServerResponse(Message: "Recruit General Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruitGeneralSetting>(recruitGeneralSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Recruit General Setting deleted successfully", Data: recruitGeneralSetting);
    }
}











