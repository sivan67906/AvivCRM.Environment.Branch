using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.Command.CreateDatePattern;

internal class CreateDatePatternCommandHandler(IValidator<CreateDatePatternRequest> validator,
    IDatePattern _datePatternRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDatePatternCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateDatePatternCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.DatePattern);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        DatePattern datePatternEntity = mapper.Map<DatePattern>(request.DatePattern);

        try
        {
            _datePatternRepository.Add(datePatternEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "DatePattern created successfully", Data: datePatternEntity);
    }
}
























