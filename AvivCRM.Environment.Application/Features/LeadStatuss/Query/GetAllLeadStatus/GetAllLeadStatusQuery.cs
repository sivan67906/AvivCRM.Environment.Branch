#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Query.GetAllLeadStatus;
public record GetAllLeadStatusQuery : IRequest<ServerResponse>;