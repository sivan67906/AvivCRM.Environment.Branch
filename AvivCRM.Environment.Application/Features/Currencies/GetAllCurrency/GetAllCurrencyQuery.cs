﻿#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.GetAllCurrency;
public record GetAllCurrencyQuery : IRequest<ServerResponse>;