using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.DeleteCustomQuestionPosition;

internal class DeleteCustomQuestionPositionCommandHandler(ICustomQuestionPosition _customQuestionPositionRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteCustomQuestionPositionCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCustomQuestionPositionCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var customQuestionPosition = await _customQuestionPositionRepository.GetByIdAsync(request.Id);
        if (customQuestionPosition is null) return new ServerResponse(Message: "Custom Question Position Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<CustomQuestionPosition>(customQuestionPosition);

        try
        {
            // Delete plan type
            _customQuestionPositionRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Position Deleted Successfully", Data: customQuestionPosition);
    }
}











