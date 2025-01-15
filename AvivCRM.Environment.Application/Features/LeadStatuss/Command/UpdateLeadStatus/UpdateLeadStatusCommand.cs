#region

using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Command.UpdateLeadStatus;
public record UpdateLeadStatusCommand(UpdateLeadStatusRequest LeadStatus) : IRequest<ServerResponse>;