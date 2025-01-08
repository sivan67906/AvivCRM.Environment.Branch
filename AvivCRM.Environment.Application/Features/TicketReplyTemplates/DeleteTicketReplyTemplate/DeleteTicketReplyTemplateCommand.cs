#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.DeleteTicketReplyTemplate;
public record DeleteTicketReplyTemplateCommand(Guid Id) : IRequest<ServerResponse>;