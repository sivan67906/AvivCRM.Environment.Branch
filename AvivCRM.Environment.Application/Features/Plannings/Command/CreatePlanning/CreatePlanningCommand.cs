#region

using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Command.CreatePlanning;
public record CreatePlanningCommand(CreatePlanningRequest Planning) : IRequest<ServerResponse>;