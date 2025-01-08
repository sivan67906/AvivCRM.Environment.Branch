#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.GetAllProjectSetting;
public record GetAllProjectSettingQuery : IRequest<ServerResponse>;