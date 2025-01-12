using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.GetToggleValueById;

public record GetToggleValueByIdQuery(Guid Id) : IRequest<ServerResponse>;








































