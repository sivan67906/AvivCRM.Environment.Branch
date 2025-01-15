#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Query.GetLeadAgentById;
public record GetLeadAgentByIdQuery(Guid Id) : IRequest<ServerResponse>;