#region

using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.UpdateRecruitJobApplicationStatusSetting;
public record UpdateRecruitJobApplicationStatusSettingCommand(
    UpdateRecruitJobApplicationStatusSettingRequest RecruitJobApplicationStatusSetting) : IRequest<ServerResponse>;