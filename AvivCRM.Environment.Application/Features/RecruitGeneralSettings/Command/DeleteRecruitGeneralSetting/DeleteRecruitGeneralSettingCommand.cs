#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Command.DeleteRecruitGeneralSetting;
public record DeleteRecruitGeneralSettingCommand(Guid Id) : IRequest<ServerResponse>;