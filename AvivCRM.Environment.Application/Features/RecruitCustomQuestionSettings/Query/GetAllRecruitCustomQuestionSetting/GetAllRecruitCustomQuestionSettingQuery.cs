#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Query.GetAllRecruitCustomQuestionSetting;
public record GetAllRecruitCustomQuestionSettingQuery : IRequest<ServerResponse>;