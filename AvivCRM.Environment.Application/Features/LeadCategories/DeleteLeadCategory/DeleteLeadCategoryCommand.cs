using MediatR;
using AvivCRM.Environment.Domain.Responses;

namespace AvivCRM.Environment.Application.Features.LeadCategories.DeleteLeadCategory;
public record DeleteLeadCategoryCommand(Guid Id) : IRequest<ServerResponse>;