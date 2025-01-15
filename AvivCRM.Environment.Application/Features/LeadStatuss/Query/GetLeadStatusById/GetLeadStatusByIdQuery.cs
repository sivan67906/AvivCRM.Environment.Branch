#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Query.GetLeadStatusById;
public record GetLeadStatusByIdQuery(Guid Id) : IRequest<ServerResponse>;