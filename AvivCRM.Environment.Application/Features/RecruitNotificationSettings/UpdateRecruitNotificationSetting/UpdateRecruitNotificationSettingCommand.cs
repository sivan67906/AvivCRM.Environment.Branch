#region

using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.UpdateRecruitNotificationSetting;
public record UpdateRecruitNotificationSettingCommand(
    UpdateRecruitNotificationSettingRequest RecruitNotificationSetting) : IRequest<ServerResponse>;