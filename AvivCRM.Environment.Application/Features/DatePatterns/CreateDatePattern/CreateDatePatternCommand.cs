using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.CreateDatePattern;

public record CreateDatePatternCommand(CreateDatePatternRequest DatePattern) : IRequest<ServerResponse>;






















