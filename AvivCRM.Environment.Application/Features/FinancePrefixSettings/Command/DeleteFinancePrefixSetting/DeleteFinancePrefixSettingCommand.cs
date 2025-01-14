#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.DeleteFinancePrefixSetting;
public record DeleteFinancePrefixSettingCommand(Guid Id) : IRequest<ServerResponse>;