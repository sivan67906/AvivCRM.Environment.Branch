using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.UpdateLeadStatus;
public record UpdateLeadStatusCommand(UpdateLeadStatusRequest LeadStatus) : IRequest<ServerResponse>;