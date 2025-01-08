#region

using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.UpdateRecruitGeneralSetting;
public record UpdateRecruitGeneralSettingCommand(UpdateRecruitGeneralSettingRequest RecruitGeneralSetting)
    : IRequest<ServerResponse>;