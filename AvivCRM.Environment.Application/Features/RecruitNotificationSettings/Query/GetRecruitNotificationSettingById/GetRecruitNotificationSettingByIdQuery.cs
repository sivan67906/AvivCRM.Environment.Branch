#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Query.GetRecruitNotificationSettingById;
public record GetRecruitNotificationSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;