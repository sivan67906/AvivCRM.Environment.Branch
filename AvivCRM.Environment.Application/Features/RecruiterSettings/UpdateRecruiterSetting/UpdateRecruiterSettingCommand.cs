#region

using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.UpdateRecruiterSetting;
public record UpdateRecruiterSettingCommand(UpdateRecruiterSettingRequest RecruiterSetting) : IRequest<ServerResponse>;