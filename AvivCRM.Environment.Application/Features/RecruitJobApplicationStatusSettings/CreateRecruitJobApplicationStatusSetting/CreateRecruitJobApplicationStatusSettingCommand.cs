using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.CreateRecruitJobApplicationStatusSetting;

public record CreateRecruitJobApplicationStatusSettingCommand(CreateRecruitJobApplicationStatusSettingRequest RecruitJobApplicationStatusSetting) : IRequest<ServerResponse>;









