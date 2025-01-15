#region

using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Command.UpdateRecruitGeneralSetting;
public record UpdateRecruitGeneralSettingCommand(UpdateRecruitGeneralSettingRequest RecruitGeneralSetting)
    : IRequest<ServerResponse>;