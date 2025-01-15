#region

using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.CreateRecruitNotificationSetting;
public record CreateRecruitNotificationSettingCommand(
    CreateRecruitNotificationSettingRequest RecruitNotificationSetting) : IRequest<ServerResponse>;