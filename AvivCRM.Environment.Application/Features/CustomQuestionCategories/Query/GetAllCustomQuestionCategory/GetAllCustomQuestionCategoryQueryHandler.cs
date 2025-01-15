#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Query.GetAllCustomQuestionCategory;
internal class GetAllCustomQuestionCategoryQueryHandler(
    ICustomQuestionCategory _customQuestionCategoryRepository,
    IMapper mapper) : IRequestHandler<GetAllCustomQuestionCategoryQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllCustomQuestionCategoryQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Recruit.CustomQuestionCategory>? customQuestionCategory = await _customQuestionCategoryRepository.GetAllAsync();
        if (customQuestionCategory is null)
        {
            return new ServerResponse(Message: "No Custom Question Category Found");
        }

        // Map the plan types to the response
        IEnumerable<GetCustomQuestionCategory>? leadSourcResponse = mapper.Map<IEnumerable<GetCustomQuestionCategory>>(customQuestionCategory);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        return new ServerResponse(true, "List of Custom Question Categories", leadSourcResponse);
    }
}