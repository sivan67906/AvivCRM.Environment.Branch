#region

using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Command.CreateApplication;
public record CreateApplicationCommand(CreateApplicationRequest Application) : IRequest<ServerResponse>;