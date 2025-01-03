using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetFinanceUnitSettingById;

public record GetFinanceUnitSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









