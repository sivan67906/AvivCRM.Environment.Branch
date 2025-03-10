#region

using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.CreateRecruitCustomQuestionSetting;
public record CreateRecruitCustomQuestionSettingCommand(
    CreateRecruitCustomQuestionSettingRequest RecruitCustomQuestionSetting) : IRequest<ServerResponse>;