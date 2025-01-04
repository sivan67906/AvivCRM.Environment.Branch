using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.NotificationMains.UpdateNotificationMain;

public record UpdateNotificationMainCommand(UpdateNotificationMainRequest NotificationMain) : IRequest<ServerResponse>;









