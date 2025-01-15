#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Query.GetAllRecruitFooterSetting;
public record GetAllRecruitFooterSettingQuery : IRequest<ServerResponse>;