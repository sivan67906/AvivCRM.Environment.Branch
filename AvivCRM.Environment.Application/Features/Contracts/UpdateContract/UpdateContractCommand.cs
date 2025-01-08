﻿#region

using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.UpdateContract;
public record UpdateContractCommand(UpdateContractRequest Contract) : IRequest<ServerResponse>;