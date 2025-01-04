using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.CreateRecruitFooterSetting;

public record CreateRecruitFooterSettingCommand(CreateRecruitFooterSettingRequest RecruitFooterSetting) : IRequest<ServerResponse>;









