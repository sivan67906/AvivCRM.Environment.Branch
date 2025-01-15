#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.DeleteRecruitCustomQuestionSetting;
public record DeleteRecruitCustomQuestionSettingCommand(Guid Id) : IRequest<ServerResponse>;