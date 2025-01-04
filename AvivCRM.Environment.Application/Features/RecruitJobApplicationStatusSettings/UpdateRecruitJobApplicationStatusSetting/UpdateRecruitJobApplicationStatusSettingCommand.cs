using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.UpdateRecruitJobApplicationStatusSetting;

public record UpdateRecruitJobApplicationStatusSettingCommand(UpdateRecruitJobApplicationStatusSettingRequest RecruitJobApplicationStatusSetting) : IRequest<ServerResponse>;









