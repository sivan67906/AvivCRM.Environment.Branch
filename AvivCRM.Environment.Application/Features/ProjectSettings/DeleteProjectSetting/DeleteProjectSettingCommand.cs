using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectSettings.DeleteProjectSetting;
public record DeleteProjectSettingCommand(Guid Id) : IRequest<ServerResponse>;









