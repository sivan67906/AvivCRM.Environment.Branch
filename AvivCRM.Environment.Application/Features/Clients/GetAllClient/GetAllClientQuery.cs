﻿#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.GetAllClient;
public record GetAllClientQuery : IRequest<ServerResponse>;