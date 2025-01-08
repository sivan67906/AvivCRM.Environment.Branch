#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.DeleteLeadSource;
public record DeleteLeadSourceCommand(Guid Id) : IRequest<ServerResponse>;