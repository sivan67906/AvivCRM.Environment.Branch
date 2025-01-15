#region

using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Command.CreateRecruitGeneralSetting;
public record CreateRecruitGeneralSettingCommand(CreateRecruitGeneralSettingRequest RecruitGeneralSetting)
    : IRequest<ServerResponse>;