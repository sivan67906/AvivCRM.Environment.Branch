using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.Query.GetTimeZoneStandardById;

public record GetTimeZoneStandardByIdQuery(Guid Id) : IRequest<ServerResponse>;






















