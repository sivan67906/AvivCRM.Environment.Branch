using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetRecruitFooterSettingById;

public record GetRecruitFooterSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









