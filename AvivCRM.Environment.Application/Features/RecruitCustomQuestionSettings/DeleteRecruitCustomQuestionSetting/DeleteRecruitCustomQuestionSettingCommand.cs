using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.DeleteRecruitCustomQuestionSetting;
public record DeleteRecruitCustomQuestionSettingCommand(Guid Id) : IRequest<ServerResponse>;









