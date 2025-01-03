using MediatR;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadCategories.GetAllLeadCategories;

public record GetAllLeadCategoryQuery : IRequest<ServerResponse>;