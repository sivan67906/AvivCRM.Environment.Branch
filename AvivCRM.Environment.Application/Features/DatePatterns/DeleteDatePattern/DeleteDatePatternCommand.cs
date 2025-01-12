using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.DeleteDatePattern;
public record DeleteDatePatternCommand(Guid Id) : IRequest<ServerResponse>;






















