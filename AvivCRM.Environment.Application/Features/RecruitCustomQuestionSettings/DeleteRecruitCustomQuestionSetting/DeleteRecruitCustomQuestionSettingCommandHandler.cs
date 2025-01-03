using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.DeleteRecruitCustomQuestionSetting;

internal class DeleteRecruitCustomQuestionSettingCommandHandler(IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteRecruitCustomQuestionSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteRecruitCustomQuestionSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var recruitCustomQuestionSetting = await _recruitCustomQuestionSettingRepository.GetByIdAsync(request.Id);
        if (recruitCustomQuestionSetting is null) return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<RecruitCustomQuestionSetting>(recruitCustomQuestionSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Recruit Custom Question Setting Deleted Successfully", Data: recruitCustomQuestionSetting);
    }
}











