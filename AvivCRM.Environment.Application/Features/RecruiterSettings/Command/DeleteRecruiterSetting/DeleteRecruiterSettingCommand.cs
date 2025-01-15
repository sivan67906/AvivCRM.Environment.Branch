#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Command.DeleteRecruiterSetting;
public record DeleteRecruiterSettingCommand(Guid Id) : IRequest<ServerResponse>;