﻿#region

using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.CreateClient;
public record CreateClientCommand(CreateClientRequest Client) : IRequest<ServerResponse>;