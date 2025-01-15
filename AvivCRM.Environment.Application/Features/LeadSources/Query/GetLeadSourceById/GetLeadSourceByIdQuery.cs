#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Query.GetLeadSourceById;
public record GetLeadSourceByIdQuery(Guid Id) : IRequest<ServerResponse>;