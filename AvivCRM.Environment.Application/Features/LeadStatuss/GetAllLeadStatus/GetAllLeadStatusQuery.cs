using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.GetAllLeadStatus;
public record GetAllLeadStatusQuery : IRequest<ServerResponse>;
