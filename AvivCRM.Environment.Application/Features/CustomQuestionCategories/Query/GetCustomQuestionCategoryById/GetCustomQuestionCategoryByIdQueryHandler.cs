#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Query.GetCustomQuestionCategoryById;
internal class GetCustomQuestionCategoryByIdQueryHandler(
    ICustomQuestionCategory customQuestionCategoryRepository,
    IMapper mapper) : IRequestHandler<GetCustomQuestionCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetCustomQuestionCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Custom Question Category by id
        Domain.Entities.Recruit.CustomQuestionCategory? customQuestionCategory = await customQuestionCategoryRepository.GetByIdAsync(request.Id);
        if (customQuestionCategory is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        // Map the entity to the response
        GetCustomQuestionCategory? customQuestionCategoryResponse =
            mapper.Map<GetCustomQuestionCategory>(customQuestionCategory); // <DTO> (parameter)
        if (customQuestionCategoryResponse is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        return new ServerResponse(true, "List of Custom Question Category", customQuestionCategoryResponse);
    }
}