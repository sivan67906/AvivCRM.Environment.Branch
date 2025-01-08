#region

using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.CreateRecruiterSetting;
public record CreateRecruiterSettingCommand(CreateRecruiterSettingRequest RecruiterSetting) : IRequest<ServerResponse>;