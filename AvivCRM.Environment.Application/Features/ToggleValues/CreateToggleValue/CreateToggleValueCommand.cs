using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.CreateToggleValue;

public record CreateToggleValueCommand(CreateToggleValueRequest ToggleValue) : IRequest<ServerResponse>;








































