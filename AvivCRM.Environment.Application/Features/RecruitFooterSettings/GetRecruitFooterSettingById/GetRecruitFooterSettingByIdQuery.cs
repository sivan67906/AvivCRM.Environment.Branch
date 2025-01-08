#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetRecruitFooterSettingById;
public record GetRecruitFooterSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;