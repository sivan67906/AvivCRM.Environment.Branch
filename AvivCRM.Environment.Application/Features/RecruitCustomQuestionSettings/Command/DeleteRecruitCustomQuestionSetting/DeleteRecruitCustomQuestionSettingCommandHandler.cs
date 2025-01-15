#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.DeleteRecruitCustomQuestionSetting;
internal class DeleteRecruitCustomQuestionSettingCommandHandler(
    IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteRecruitCustomQuestionSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitCustomQuestionSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        RecruitCustomQuestionSetting? recruitCustomQuestionSetting = await _recruitCustomQuestionSettingRepository.GetByIdAsync(request.Id);
        if (recruitCustomQuestionSetting is null)
        {
            return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");
        }

        // Map the request to the entity
        RecruitCustomQuestionSetting delMapEntity = mapper.Map<RecruitCustomQuestionSetting>(recruitCustomQuestionSetting);

        try
        {
            // Delete plan type
            _recruitCustomQuestionSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit Custom Question Setting deleted successfully",
            delMapEntity);
    }
}