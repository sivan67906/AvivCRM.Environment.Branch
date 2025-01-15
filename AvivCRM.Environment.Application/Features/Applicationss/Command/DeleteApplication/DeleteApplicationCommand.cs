#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Command.DeleteApplication;
public record DeleteApplicationCommand(Guid Id) : IRequest<ServerResponse>;