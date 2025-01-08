#region

using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.UpdatePlanning;
public record UpdatePlanningCommand(UpdatePlanningRequest Planning) : IRequest<ServerResponse>;