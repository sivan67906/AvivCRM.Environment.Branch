#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Command.CreateRecruiterSetting;
internal class CreateRecruiterSettingCommandHandler(
    IValidator<CreateRecruiterSettingRequest> validator,
    IRecruiterSetting _recruiterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruiterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruiterSettingCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruiterSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruiterSetting recruiterSettingEntity = mapper.Map<RecruiterSetting>(request.RecruiterSetting);

        try
        {
            _recruiterSettingRepository.Add(recruiterSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruiter Setting created successfully", recruiterSettingEntity);
    }
}