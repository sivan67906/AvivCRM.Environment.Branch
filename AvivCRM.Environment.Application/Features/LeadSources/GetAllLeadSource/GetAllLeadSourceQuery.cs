using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadSources.GetAllLeadSource;

public record GetAllLeadSourceQuery : IRequest<ServerResponse>;