#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetAllRecruitNotificationSetting;
public record GetAllRecruitNotificationSettingQuery : IRequest<ServerResponse>;