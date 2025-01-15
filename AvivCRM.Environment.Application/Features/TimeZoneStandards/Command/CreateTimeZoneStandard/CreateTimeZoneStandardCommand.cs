using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.Command.CreateTimeZoneStandard;

public record CreateTimeZoneStandardCommand(CreateTimeZoneStandardRequest TimeZoneStandard) : IRequest<ServerResponse>;






















