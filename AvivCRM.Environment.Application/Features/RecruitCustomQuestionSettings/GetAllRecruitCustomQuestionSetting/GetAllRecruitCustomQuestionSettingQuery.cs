#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetAllRecruitCustomQuestionSetting;
public record GetAllRecruitCustomQuestionSettingQuery : IRequest<ServerResponse>;