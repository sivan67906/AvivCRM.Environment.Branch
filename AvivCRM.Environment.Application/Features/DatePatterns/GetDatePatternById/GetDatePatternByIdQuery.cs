using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.GetDatePatternById;

public record GetDatePatternByIdQuery(Guid Id) : IRequest<ServerResponse>;






















