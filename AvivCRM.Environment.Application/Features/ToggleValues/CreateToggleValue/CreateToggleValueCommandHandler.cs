using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.CreateToggleValue;

internal class CreateToggleValueCommandHandler(IValidator<CreateToggleValueRequest> validator,
    IToggleValue _toggleValueRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateToggleValueCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateToggleValueCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.ToggleValue);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var toggleValueEntity = mapper.Map<ToggleValue>(request.ToggleValue);

        try
        {
            _toggleValueRepository.Add(toggleValueEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Toggle Value created successfully", Data: toggleValueEntity);
    }
}










































