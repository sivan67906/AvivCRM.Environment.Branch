#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.Command.DeleteCustomQuestionType;
internal class DeleteCustomQuestionTypeCommandHandler(
    ICustomQuestionType _customQuestionTypeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteCustomQuestionTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCustomQuestionTypeCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        CustomQuestionType? customQuestionType = await _customQuestionTypeRepository.GetByIdAsync(request.Id);
        if (customQuestionType is null)
        {
            return new ServerResponse(Message: "Custom Question Type Not Found");
        }

        // Map the request to the entity
        CustomQuestionType delMapEntity = mapper.Map<CustomQuestionType>(customQuestionType);

        try
        {
            // Delete plan type
            _customQuestionTypeRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Custom Question Type deleted successfully", customQuestionType);
    }
}