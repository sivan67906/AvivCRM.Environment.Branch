using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.DeleteToggleValue;
public record DeleteToggleValueCommand(Guid Id) : IRequest<ServerResponse>;








































