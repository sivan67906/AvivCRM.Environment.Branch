#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Query.GetAllLeadSource;
public record GetAllLeadSourceQuery : IRequest<ServerResponse>;