using MediatR;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadAgents.GetAllLeadAgents;

public record GetAllLeadAgentsQuery : IRequest<ServerResponse>;


