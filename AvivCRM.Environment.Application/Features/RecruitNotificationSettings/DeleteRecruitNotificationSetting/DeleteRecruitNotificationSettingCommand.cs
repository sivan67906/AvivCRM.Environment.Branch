using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.DeleteRecruitNotificationSetting;
public record DeleteRecruitNotificationSettingCommand(Guid Id) : IRequest<ServerResponse>;









