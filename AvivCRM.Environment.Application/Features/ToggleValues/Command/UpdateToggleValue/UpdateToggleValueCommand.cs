using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Command.UpdateToggleValue;

public record UpdateToggleValueCommand(UpdateToggleValueRequest ToggleValue) : IRequest<ServerResponse>;








































