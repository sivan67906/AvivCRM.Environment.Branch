#region

using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuses.CreateLeadStatus;
public record CreateLeadStatusCommand(CreateLeadStatusRequest LeadStatus) : IRequest<ServerResponse>;