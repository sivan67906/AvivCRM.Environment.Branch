using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetFinancePrefixSettingById;

public record GetFinancePrefixSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









