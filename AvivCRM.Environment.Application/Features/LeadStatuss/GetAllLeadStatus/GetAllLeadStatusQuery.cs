#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.GetAllLeadStatus;
public record GetAllLeadStatusQuery : IRequest<ServerResponse>;