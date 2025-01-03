using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.DeleteTicketReplyTemplate;
public record DeleteTicketReplyTemplateCommand(Guid Id) : IRequest<ServerResponse>;









