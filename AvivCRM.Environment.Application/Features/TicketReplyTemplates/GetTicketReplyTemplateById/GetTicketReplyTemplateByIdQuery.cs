using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetTicketReplyTemplateById;

public record GetTicketReplyTemplateByIdQuery(Guid Id) : IRequest<ServerResponse>;









