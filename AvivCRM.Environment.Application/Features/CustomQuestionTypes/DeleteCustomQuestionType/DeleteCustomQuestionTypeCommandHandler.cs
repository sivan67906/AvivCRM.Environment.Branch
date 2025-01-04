using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.DeleteCustomQuestionType;

internal class DeleteCustomQuestionTypeCommandHandler(ICustomQuestionType _customQuestionTypeRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteCustomQuestionTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCustomQuestionTypeCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var customQuestionType = await _customQuestionTypeRepository.GetByIdAsync(request.Id);
        if (customQuestionType is null) return new ServerResponse(Message: "Custom Question Type Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<CustomQuestionType>(customQuestionType);

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

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Type deleted successfully", Data: customQuestionType);
    }
}











