#region

using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.CreateRecruitFooterSetting;
public record CreateRecruitFooterSettingCommand(CreateRecruitFooterSettingRequest RecruitFooterSetting)
    : IRequest<ServerResponse>;