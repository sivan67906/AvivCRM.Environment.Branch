using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Notifications.Query.GetNotificationById;
public record GetNotificationByIdQuery(Guid Id) : IRequest<ServerResponse>;