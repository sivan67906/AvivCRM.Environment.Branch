#region

using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Command.UpdatePurchaseSetting;
public record UpdatePurchaseSettingCommand(UpdatePurchaseSettingRequest PurchaseSetting) : IRequest<ServerResponse>;