#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.Command.DeleteProjectSetting;
public record DeleteProjectSettingCommand(Guid Id) : IRequest<ServerResponse>;