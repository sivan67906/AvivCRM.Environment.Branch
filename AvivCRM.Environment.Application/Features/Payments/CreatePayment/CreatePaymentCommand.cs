﻿#region

using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.CreatePayment;
public record CreatePaymentCommand(CreatePaymentRequest Payment) : IRequest<ServerResponse>;