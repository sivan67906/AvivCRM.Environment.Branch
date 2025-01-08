using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.GetNotificationById;
public record GetNotificationByIdQuery(Guid Id) : IRequest<ServerResponse>;