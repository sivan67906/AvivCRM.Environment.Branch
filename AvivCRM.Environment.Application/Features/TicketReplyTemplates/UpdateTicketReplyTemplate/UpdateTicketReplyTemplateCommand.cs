#region

using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.UpdateTicketReplyTemplate;
public record UpdateTicketReplyTemplateCommand(UpdateTicketReplyTemplateRequest TicketReplyTemplate)
    : IRequest<ServerResponse>;