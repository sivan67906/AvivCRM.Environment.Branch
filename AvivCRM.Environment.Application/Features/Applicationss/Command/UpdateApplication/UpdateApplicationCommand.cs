#region

using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Command.UpdateApplication;
public record UpdateApplicationCommand(UpdateApplicationRequest Application) : IRequest<ServerResponse>;