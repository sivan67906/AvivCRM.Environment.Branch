using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.GetPurchaseSettingById;

public record GetPurchaseSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;













