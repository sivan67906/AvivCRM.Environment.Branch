using AutoMapper;
using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.CreateCustomQuestionPosition;

internal class CreateCustomQuestionPositionCommandHandler(IValidator<CreateCustomQuestionPositionRequest> validator,
    ICustomQuestionPosition _customQuestionPositionRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCustomQuestionPositionCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateCustomQuestionPositionCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.CustomQuestionPosition);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var customQuestionPositionEntity = mapper.Map<CustomQuestionPosition>(request.CustomQuestionPosition);

        try
        {
            _customQuestionPositionRepository.Add(customQuestionPositionEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Custom Question Position Created Succcessfully", Data: customQuestionPositionEntity);
    }
}











