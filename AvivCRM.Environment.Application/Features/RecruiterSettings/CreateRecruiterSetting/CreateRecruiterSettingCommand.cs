using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.CreateRecruiterSetting;

public record CreateRecruiterSettingCommand(CreateRecruiterSettingRequest RecruiterSetting) : IRequest<ServerResponse>;









