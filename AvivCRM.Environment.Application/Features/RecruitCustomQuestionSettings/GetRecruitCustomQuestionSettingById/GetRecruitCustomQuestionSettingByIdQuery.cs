using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetRecruitCustomQuestionSettingById;

public record GetRecruitCustomQuestionSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









