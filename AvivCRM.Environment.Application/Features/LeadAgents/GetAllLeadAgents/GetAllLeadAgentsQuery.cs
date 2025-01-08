#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.GetAllLeadAgents;
public record GetAllLeadAgentsQuery : IRequest<ServerResponse>;