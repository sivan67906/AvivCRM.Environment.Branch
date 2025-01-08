#region

using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.UpdateRecruitCustomQuestionSetting;
public record UpdateRecruitCustomQuestionSettingCommand(
    UpdateRecruitCustomQuestionSettingRequest RecruitCustomQuestionSetting) : IRequest<ServerResponse>;