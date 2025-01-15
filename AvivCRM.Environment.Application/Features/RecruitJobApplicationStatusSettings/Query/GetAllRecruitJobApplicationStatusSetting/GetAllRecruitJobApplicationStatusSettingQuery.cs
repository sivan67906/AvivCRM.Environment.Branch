#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Query.GetAllRecruitJobApplicationStatusSetting;
public record GetAllRecruitJobApplicationStatusSettingQuery : IRequest<ServerResponse>;