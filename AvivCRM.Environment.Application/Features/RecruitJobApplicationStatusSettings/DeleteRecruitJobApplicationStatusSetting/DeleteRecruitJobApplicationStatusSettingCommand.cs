using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.DeleteRecruitJobApplicationStatusSetting;
public record DeleteRecruitJobApplicationStatusSettingCommand(Guid Id) : IRequest<ServerResponse>;









