#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetAllTicketReplyTemplate;
public record GetAllTicketReplyTemplateQuery : IRequest<ServerResponse>;