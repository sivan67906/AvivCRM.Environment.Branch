using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.CreatePurchaseSetting;

public record CreatePurchaseSettingCommand(CreatePurchaseSettingRequest PurchaseSetting) : IRequest<ServerResponse>;













