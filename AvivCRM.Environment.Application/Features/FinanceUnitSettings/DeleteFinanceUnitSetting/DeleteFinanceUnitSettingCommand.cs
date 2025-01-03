using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.DeleteFinanceUnitSetting;
public record DeleteFinanceUnitSettingCommand(Guid Id) : IRequest<ServerResponse>;









