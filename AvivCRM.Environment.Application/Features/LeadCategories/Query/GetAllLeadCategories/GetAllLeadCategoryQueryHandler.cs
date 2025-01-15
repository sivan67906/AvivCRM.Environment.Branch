#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.Query.GetAllLeadCategories;
internal class GetAllLeadCategoryQueryHandler(ILeadCategory _leadCategoryRepository, IMapper mapper)
    : IRequestHandler<GetAllLeadCategoryQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllLeadCategoryQuery request, CancellationToken cancellationToken)
    {
        // Get all Lead Category
        IEnumerable<Domain.Entities.Lead.LeadCategory>? leadCategory = await _leadCategoryRepository.GetAllAsync();
        if (leadCategory is null)
        {
            return new ServerResponse(Message: "No Lead Category Found");
        }

        // Map the Lead Category to the response
        IEnumerable<GetLeadCategory>? leadCategoryResponse = mapper.Map<IEnumerable<GetLeadCategory>>(leadCategory);
        if (leadCategoryResponse is null)
        {
            return new ServerResponse(Message: "Lead Category Not Found");
        }

        return new ServerResponse(true, "List of Lead Categories", leadCategoryResponse);
    }
}