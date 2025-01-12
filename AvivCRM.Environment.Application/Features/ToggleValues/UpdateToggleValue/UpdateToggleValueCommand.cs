using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.UpdateToggleValue;

public record UpdateToggleValueCommand(UpdateToggleValueRequest ToggleValue) : IRequest<ServerResponse>;








































