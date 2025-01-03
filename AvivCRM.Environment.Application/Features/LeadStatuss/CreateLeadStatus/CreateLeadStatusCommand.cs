using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.CreateLeadStatus;
public record CreateLeadStatusCommand(CreateLeadStatusRequest LeadStatus) : IRequest<ServerResponse>;