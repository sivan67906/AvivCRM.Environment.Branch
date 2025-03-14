#region

using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.Command.CreateTicketReplyTemplate;
public record CreateTicketReplyTemplateCommand(CreateTicketReplyTemplateRequest TicketReplyTemplate)
    : IRequest<ServerResponse>;