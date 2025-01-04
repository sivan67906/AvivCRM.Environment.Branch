using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.DeleteRecruitFooterSetting;
public record DeleteRecruitFooterSettingCommand(Guid Id) : IRequest<ServerResponse>;









