#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.GetAllLeadSource;
public record GetAllLeadSourceQuery : IRequest<ServerResponse>;