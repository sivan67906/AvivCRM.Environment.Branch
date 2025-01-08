#region

using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.CreateLeadSource;
public record CreateLeadSourceCommand(CreateLeadSourceRequest LeadSource) : IRequest<ServerResponse>;