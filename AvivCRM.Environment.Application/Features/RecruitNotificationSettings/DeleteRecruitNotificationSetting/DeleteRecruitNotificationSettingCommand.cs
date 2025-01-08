#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.DeleteRecruitNotificationSetting;
public record DeleteRecruitNotificationSettingCommand(Guid Id) : IRequest<ServerResponse>;