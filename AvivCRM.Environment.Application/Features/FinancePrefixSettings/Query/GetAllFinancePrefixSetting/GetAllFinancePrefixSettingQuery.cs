#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Query.GetAllFinancePrefixSetting;
public record GetAllFinancePrefixSettingQuery : IRequest<ServerResponse>;