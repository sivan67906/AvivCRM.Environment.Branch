#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Query.GetAllRecruitGeneralSetting;
public record GetAllRecruitGeneralSettingQuery : IRequest<ServerResponse>;