using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.DeletePurchaseSetting;
public record DeletePurchaseSettingCommand(Guid Id) : IRequest<ServerResponse>;













