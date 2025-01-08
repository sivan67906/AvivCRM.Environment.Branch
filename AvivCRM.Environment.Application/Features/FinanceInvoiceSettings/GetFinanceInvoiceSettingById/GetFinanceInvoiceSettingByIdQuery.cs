﻿#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetFinanceInvoiceSettingById;
public record GetFinanceInvoiceSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;