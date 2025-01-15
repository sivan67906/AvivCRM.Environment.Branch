#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.DeleteRecruitJobApplicationStatusSetting;
public record DeleteRecruitJobApplicationStatusSettingCommand(Guid Id) : IRequest<ServerResponse>;