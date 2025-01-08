#region

using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.CreateProjectSetting;
public record CreateProjectSettingCommand(CreateProjectSettingRequest ProjectSetting) : IRequest<ServerResponse>;