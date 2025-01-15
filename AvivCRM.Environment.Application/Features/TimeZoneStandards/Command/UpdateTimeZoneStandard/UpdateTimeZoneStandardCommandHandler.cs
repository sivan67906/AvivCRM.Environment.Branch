using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.Command.UpdateTimeZoneStandard;

internal class UpdateTimeZoneStandardCommandHandler(IValidator<UpdateTimeZoneStandardRequest> _validator, ITimeZoneStandard _timeZoneStandardRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateTimeZoneStandardCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTimeZoneStandardCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.TimeZoneStandard);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the timeZone Standard exists
        TimeZoneStandard? timeZoneStandard = await _timeZoneStandardRepository.GetByIdAsync(request.TimeZoneStandard.Id);
        if (timeZoneStandard is null) return new ServerResponse(Message: "TimeZone Standard Not Found");

        // Map the request to the entity
        TimeZoneStandard timeZoneStandardEntity = mapper.Map<TimeZoneStandard>(request.TimeZoneStandard);

        try
        {
            // Update the timeZone Standard
            _timeZoneStandardRepository.Update(timeZoneStandardEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "TimeZone Standard updated successfully", Data: timeZoneStandardEntity);
    }
}






















