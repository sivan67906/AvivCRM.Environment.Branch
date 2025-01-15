#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.Query.GetProjectSettingById;
public record GetProjectSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;