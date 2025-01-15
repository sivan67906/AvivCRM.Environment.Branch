using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Command.UpdateDatePattern;

public record UpdateDatePatternCommand(UpdateDatePatternRequest DatePattern) : IRequest<ServerResponse>;






















