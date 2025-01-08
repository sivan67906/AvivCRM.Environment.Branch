#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.NotificationMains.GetNotificationMainById;
public record GetNotificationMainByIdQuery(Guid Id) : IRequest<ServerResponse>;