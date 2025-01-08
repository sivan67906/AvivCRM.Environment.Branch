#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.DeleteLeadStatus;
public record DeleteLeadStatusCommand(Guid Id) : IRequest<ServerResponse>;