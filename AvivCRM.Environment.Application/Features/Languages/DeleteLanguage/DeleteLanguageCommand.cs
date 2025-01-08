﻿#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.DeleteLanguage;
public record DeleteLanguageCommand(Guid Id) : IRequest<ServerResponse>;