#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Query.GetFinancePrefixSettingById;
public record GetFinancePrefixSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;