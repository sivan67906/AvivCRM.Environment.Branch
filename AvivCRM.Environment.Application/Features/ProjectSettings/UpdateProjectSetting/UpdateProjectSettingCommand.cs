#region

using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.UpdateProjectSetting;
public record UpdateProjectSettingCommand(UpdateProjectSettingRequest ProjectSetting) : IRequest<ServerResponse>;