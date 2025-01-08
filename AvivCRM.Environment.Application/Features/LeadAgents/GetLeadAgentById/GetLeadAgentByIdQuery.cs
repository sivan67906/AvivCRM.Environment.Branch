#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.GetLeadAgentById;
public record GetLeadAgentByIdQuery(Guid Id) : IRequest<ServerResponse>;