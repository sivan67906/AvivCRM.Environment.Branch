using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.DeleteFinancePrefixSetting;
public record DeleteFinancePrefixSettingCommand(Guid Id) : IRequest<ServerResponse>;









