using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Command.DeleteDatePattern;
public record DeleteDatePatternCommand(Guid Id) : IRequest<ServerResponse>;






















