#region

using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.UpdateRecruitFooterSetting;
public record UpdateRecruitFooterSettingCommand(UpdateRecruitFooterSettingRequest RecruitFooterSetting)
    : IRequest<ServerResponse>;