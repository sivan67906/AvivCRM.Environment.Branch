using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.NotificationMains.GetNotificationMainById;

public record GetNotificationMainByIdQuery(Guid Id) : IRequest<ServerResponse>;









