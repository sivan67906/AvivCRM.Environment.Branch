using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.UpdateTimeZoneStandard;

public record UpdateTimeZoneStandardCommand(UpdateTimeZoneStandardRequest TimeZoneStandard) : IRequest<ServerResponse>;






















