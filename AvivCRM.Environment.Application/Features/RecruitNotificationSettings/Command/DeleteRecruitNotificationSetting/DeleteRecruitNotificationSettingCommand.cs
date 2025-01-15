#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.DeleteRecruitNotificationSetting;
public record DeleteRecruitNotificationSettingCommand(Guid Id) : IRequest<ServerResponse>;