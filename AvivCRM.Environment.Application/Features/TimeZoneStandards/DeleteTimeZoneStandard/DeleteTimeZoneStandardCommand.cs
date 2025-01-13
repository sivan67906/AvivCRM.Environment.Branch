using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.DeleteTimeZoneStandard;
public record DeleteTimeZoneStandardCommand(Guid Id) : IRequest<ServerResponse>;






















