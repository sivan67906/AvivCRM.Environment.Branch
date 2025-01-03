using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.DeleteCustomQuestionCategory;

internal class DeleteCustomQuestionCategoryCommandHandler(ICustomQuestionCategory _customQuestionCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteCustomQuestionCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCustomQuestionCategoryCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var customQuestionCategory = await _customQuestionCategoryRepository.GetByIdAsync(request.Id);
        if (customQuestionCategory is null) return new ServerResponse(Message: "Custom Question Category Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<CustomQuestionCategory>(customQuestionCategory);

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

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Category Deleted Successfully", Data: customQuestionCategory);
    }
}











