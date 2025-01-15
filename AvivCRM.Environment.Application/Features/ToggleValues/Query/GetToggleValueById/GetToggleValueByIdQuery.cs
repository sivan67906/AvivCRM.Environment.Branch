using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Query.GetToggleValueById;

public record GetToggleValueByIdQuery(Guid Id) : IRequest<ServerResponse>;








































