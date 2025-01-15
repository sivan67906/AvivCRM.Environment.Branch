#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Query.GetAllLeadAgents;
public record GetAllLeadAgentsQuery : IRequest<ServerResponse>;