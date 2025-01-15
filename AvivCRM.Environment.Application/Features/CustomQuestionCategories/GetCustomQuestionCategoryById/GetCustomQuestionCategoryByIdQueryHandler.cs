#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetCustomQuestionCategoryById;
internal class GetCustomQuestionCategoryByIdQueryHandler(
    ICustomQuestionCategory customQuestionCategoryRepository,
    IMapper mapper) : IRequestHandler<GetCustomQuestionCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetCustomQuestionCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Custom Question Category by id
        var customQuestionCategory = await customQuestionCategoryRepository.GetByIdAsync(request.Id);
        if (customQuestionCategory is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        // Map the entity to the response
        var customQuestionCategoryResponse =
            mapper.Map<GetCustomQuestionCategory>(customQuestionCategory); // <DTO> (parameter)
        if (customQuestionCategoryResponse is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        return new ServerResponse(true, "List of Custom Question Category", customQuestionCategoryResponse);
    }
}