#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuses.GetAllLeadStatus;
public record GetAllLeadStatusQuery : IRequest<ServerResponse>;