﻿#region

using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.CreateTax;
public record CreateTaxCommand(CreateTaxRequest Tax) : IRequest<ServerResponse>;