using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Command.CreateDatePattern;

public record CreateDatePatternCommand(CreateDatePatternRequest DatePattern) : IRequest<ServerResponse>;






















