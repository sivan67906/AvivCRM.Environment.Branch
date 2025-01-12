using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.GetTimeZoneStandardById;

public record GetTimeZoneStandardByIdQuery(Guid Id) : IRequest<ServerResponse>;






















