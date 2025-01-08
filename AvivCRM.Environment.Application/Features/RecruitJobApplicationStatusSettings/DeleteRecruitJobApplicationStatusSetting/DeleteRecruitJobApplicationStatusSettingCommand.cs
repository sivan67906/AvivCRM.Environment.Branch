#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    DeleteRecruitJobApplicationStatusSetting;
public record DeleteRecruitJobApplicationStatusSettingCommand(Guid Id) : IRequest<ServerResponse>;