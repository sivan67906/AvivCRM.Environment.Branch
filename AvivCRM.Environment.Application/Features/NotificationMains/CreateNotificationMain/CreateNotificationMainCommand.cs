using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.NotificationMains.CreateNotificationMain;

public record CreateNotificationMainCommand(CreateNotificationMainRequest NotificationMain) : IRequest<ServerResponse>;









