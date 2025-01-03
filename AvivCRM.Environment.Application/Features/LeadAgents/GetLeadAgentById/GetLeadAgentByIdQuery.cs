using MediatR;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadAgents.GetLeadAgentById;

public record GetLeadAgentByIdQuery(Guid Id) : IRequest<ServerResponse>;


