﻿#region

using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.UpdatePayment;
public record UpdatePaymentCommand(UpdatePaymentRequest Payment) : IRequest<ServerResponse>;