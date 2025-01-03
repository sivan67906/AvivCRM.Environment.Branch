using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetRecruitNotificationSettingById;

public record GetRecruitNotificationSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









