#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.Query.GetTicketReplyTemplateById;
public record GetTicketReplyTemplateByIdQuery(Guid Id) : IRequest<ServerResponse>;