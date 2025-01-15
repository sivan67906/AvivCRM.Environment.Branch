using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Command.CreateToggleValue;

public record CreateToggleValueCommand(CreateToggleValueRequest ToggleValue) : IRequest<ServerResponse>;








































