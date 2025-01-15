#region

using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Command.UpdateLeadSource;
public record UpdateLeadSourceCommand(UpdateLeadSourceRequest LeadSource) : IRequest<ServerResponse>;