#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Command.DeletePurchaseSetting;
public record DeletePurchaseSettingCommand(Guid Id) : IRequest<ServerResponse>;