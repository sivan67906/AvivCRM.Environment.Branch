using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadAgents.DeleteLeadAgent
{
    public record DeleteLeadAgentCommand(Guid Id) : IRequest<ServerResponse>;
}


