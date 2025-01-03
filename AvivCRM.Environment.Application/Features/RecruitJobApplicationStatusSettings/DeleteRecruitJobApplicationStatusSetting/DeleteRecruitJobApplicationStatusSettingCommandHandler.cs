using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.DeleteRecruitJobApplicationStatusSetting;

internal class DeleteRecruitJobApplicationStatusSettingCommandHandler(IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteRecruitJobApplicationStatusSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitJobApplicationStatusSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var recruitJobApplicationStatusSetting = await _recruitJobApplicationStatusSettingRepository.GetByIdAsync(request.Id);
        if (recruitJobApplicationStatusSetting is null) return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruitJobApplicationStatusSetting>(recruitJobApplicationStatusSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Recruit JobApplication Status Setting Deleted Successfully", Data: recruitJobApplicationStatusSetting);
    }
}











