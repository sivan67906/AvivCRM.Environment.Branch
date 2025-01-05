﻿using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Clients.UpdateClient;
public record UpdateClientCommand(UpdateClientRequest Client) : IRequest<ServerResponse>;