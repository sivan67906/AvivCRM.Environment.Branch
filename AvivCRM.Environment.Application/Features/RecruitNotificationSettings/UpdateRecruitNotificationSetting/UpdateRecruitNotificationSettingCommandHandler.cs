using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.UpdateRecruitNotificationSetting;

internal class UpdateRecruitNotificationSettingCommandHandler(IValidator<UpdateRecruitNotificationSettingRequest> _validator, IRecruitNotificationSetting _recruitNotificationSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateRecruitNotificationSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitNotificationSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.RecruitNotificationSetting);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var recruitNotificationSetting = await _recruitNotificationSettingRepository.GetByIdAsync(request.RecruitNotificationSetting.Id);
        if (recruitNotificationSetting is null) return new ServerResponse(Message: "Recruit Notification Setting Not Found");

        // Map the request to the entity
        var recruitNotificationSettingEntity = mapper.Map<RecruitNotificationSetting>(request.RecruitNotificationSetting);

        try
        {
            // Update the lead Source
            _recruitNotificationSettingRepository.Update(recruitNotificationSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Recruit Notification Setting Updated Successfully", Data: recruitNotificationSetting);
    }
}









