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

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Command.UpdateRecruiterSetting;
internal class UpdateRecruiterSettingCommandHandler(
    IValidator<UpdateRecruiterSettingRequest> _validator,
    IRecruiterSetting _recruiterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecruiterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruiterSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.RecruiterSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        RecruiterSetting? recruiterSetting = await _recruiterSettingRepository.GetByIdAsync(request.RecruiterSetting.Id);
        if (recruiterSetting is null)
        {
            return new ServerResponse(Message: "Recruiter Setting Not Found");
        }

        // Map the request to the entity
        RecruiterSetting recruiterSettingEntity = mapper.Map<RecruiterSetting>(request.RecruiterSetting);

        try
        {
            // Update the lead Source
            _recruiterSettingRepository.Update(recruiterSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruiter Setting updated successfully", recruiterSettingEntity);
    }
}