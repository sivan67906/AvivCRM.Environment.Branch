using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.CreateTimeZoneStandard;

internal class CreateTimeZoneStandardCommandHandler(IValidator<CreateTimeZoneStandardRequest> validator,
    ITimeZoneStandard _timeZoneStandardRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTimeZoneStandardCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTimeZoneStandardCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TimeZoneStandard);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var timeZoneStandardEntity = mapper.Map<TimeZoneStandard>(request.TimeZoneStandard);

        try
        {
            _timeZoneStandardRepository.Add(timeZoneStandardEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "TimeZone Standard created successfully", Data: timeZoneStandardEntity);
    }
}
























