#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.DeleteFinanceUnitSetting;
public record DeleteFinanceUnitSettingCommand(Guid Id) : IRequest<ServerResponse>;