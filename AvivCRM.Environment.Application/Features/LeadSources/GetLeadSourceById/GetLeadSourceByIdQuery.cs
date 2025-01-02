using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadSources.GetLeadSourceById;

public record GetLeadSourceByIdQuery(Guid Id) : IRequest<ServerResponse>;