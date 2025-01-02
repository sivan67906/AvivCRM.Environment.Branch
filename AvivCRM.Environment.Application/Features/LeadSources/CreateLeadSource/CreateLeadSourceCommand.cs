using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadSources.CreateLeadSource;

public record CreateLeadSourceCommand(CreateLeadSourceRequest LeadSource) : IRequest<ServerResponse>;