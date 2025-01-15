#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Query.GetAllPurchaseSetting;
public record GetAllPurchaseSettingQuery : IRequest<ServerResponse>;