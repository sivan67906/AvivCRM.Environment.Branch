#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    GetAllRecruitJobApplicationStatusSetting;
public record GetAllRecruitJobApplicationStatusSettingQuery : IRequest<ServerResponse>;