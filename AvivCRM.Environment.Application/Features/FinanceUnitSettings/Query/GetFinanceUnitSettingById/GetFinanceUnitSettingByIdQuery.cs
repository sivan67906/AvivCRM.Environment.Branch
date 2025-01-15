#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetFinanceUnitSettingById;
public record GetFinanceUnitSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;