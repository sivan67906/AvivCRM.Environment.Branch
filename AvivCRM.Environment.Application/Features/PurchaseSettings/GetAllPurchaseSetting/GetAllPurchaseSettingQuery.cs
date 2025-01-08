#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.GetAllPurchaseSetting;
public record GetAllPurchaseSettingQuery : IRequest<ServerResponse>;