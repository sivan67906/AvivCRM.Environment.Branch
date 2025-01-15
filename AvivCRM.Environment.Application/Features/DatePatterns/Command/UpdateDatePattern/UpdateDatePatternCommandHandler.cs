using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Command.UpdateDatePattern;

internal class UpdateDatePatternCommandHandler(IValidator<UpdateDatePatternRequest> _validator, IDatePattern _datePatternRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateDatePatternCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateDatePatternCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.DatePattern);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the datePattern exists
        DatePattern? datePattern = await _datePatternRepository.GetByIdAsync(request.DatePattern.Id);
        if (datePattern is null) return new ServerResponse(Message: "DatePattern Not Found");

        // Map the request to the entity
        DatePattern datePatternEntity = mapper.Map<DatePattern>(request.DatePattern);

        try
        {
            // Update the datePattern
            _datePatternRepository.Update(datePatternEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "DatePattern updated successfully", Data: datePatternEntity);
    }
}






















