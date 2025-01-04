using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetRecruitGeneralSettingById;

public record GetRecruitGeneralSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









