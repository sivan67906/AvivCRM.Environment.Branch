using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.UpdateRecruitFooterSetting;

public record UpdateRecruitFooterSettingCommand(UpdateRecruitFooterSettingRequest RecruitFooterSetting) : IRequest<ServerResponse>;









