#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.Query.GetAllProjectSetting;
public record GetAllProjectSettingQuery : IRequest<ServerResponse>;