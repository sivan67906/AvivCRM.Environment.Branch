#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetRecruitNotificationSettingById;
public record GetRecruitNotificationSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;