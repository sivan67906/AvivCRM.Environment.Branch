#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.Command.DeleteCustomQuestionCategory;
internal class DeleteCustomQuestionCategoryCommandHandler(
    ICustomQuestionCategory _customQuestionCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteCustomQuestionCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCustomQuestionCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        CustomQuestionCategory? customQuestionCategory = await _customQuestionCategoryRepository.GetByIdAsync(request.Id);
        if (customQuestionCategory is null)
        {
            return new ServerResponse(Message: "Custom Question Category Not Found");
        }

        // Map the request to the entity
        CustomQuestionCategory delMapEntity = mapper.Map<CustomQuestionCategory>(customQuestionCategory);

        try
        {
            // Delete plan type
            _customQuestionCategoryRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Custom Question Category deleted successfully", customQuestionCategory);
    }
}