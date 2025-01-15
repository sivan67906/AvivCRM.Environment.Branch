#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Query.GetAllRecruitNotificationSetting;
public record GetAllRecruitNotificationSettingQuery : IRequest<ServerResponse>;