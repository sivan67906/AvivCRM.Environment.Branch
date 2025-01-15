using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Command.DeleteToggleValue;
public record DeleteToggleValueCommand(Guid Id) : IRequest<ServerResponse>;








































