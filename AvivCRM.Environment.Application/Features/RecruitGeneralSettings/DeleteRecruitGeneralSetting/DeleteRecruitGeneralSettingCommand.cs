using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.DeleteRecruitGeneralSetting;
public record DeleteRecruitGeneralSettingCommand(Guid Id) : IRequest<ServerResponse>;









