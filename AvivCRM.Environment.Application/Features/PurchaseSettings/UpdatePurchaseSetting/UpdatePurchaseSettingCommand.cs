using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.UpdatePurchaseSetting;

public record UpdatePurchaseSettingCommand(UpdatePurchaseSettingRequest PurchaseSetting) : IRequest<ServerResponse>;












