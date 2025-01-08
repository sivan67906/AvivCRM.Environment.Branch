#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.DeleteRecruiterSetting;
public record DeleteRecruiterSettingCommand(Guid Id) : IRequest<ServerResponse>;