#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetTicketReplyTemplateById;
public record GetTicketReplyTemplateByIdQuery(Guid Id) : IRequest<ServerResponse>;