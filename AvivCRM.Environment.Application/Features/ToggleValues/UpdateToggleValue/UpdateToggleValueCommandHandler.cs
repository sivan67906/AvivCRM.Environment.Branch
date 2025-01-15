using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.UpdateToggleValue;

internal class UpdateToggleValueCommandHandler(IValidator<UpdateToggleValueRequest> _validator, IToggleValue _toggleValueRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateToggleValueCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateToggleValueCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.ToggleValue);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the toggle Value exists
        var toggleValue = await _toggleValueRepository.GetByIdAsync(request.ToggleValue.Id);
        if (toggleValue is null) return new ServerResponse(Message: "Toggle Value Not Found");

        // Map the request to the entity
        var toggleValueEntity = mapper.Map<ToggleValue>(request.ToggleValue);

        try
        {
            // Update the toggle Value
            _toggleValueRepository.Update(toggleValueEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Toggle Value updated successfully", Data: toggleValueEntity);
    }
}








































