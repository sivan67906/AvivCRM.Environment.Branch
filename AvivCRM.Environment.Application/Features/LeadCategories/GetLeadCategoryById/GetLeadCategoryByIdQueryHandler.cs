#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.GetLeadCategoryById;
internal class GetLeadCategoryByIdQueryHandler(ILeadCategory _leadCategoryRepository, IMapper mapper)
    : IRequestHandler<GetLeadCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetLeadCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the plan type by id
        var leadCategory = await _leadCategoryRepository.GetByIdAsync(request.Id);
        if (leadCategory is null)
        {
            return new ServerResponse(Message: "Lead Category Not Found");
        }

        // Map the entity to the response
        var planTypeResponse = mapper.Map<GetLeadCategory>(leadCategory);
        if (planTypeResponse is null)
        {
            return new ServerResponse(Message: "Lead Category Not Found");
        }

        return new ServerResponse(true, "List of Lead Category", planTypeResponse);
    }
}