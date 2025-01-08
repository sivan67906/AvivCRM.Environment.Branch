#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    UpdateRecruitJobApplicationStatusSetting;
internal class UpdateRecruitJobApplicationStatusSettingCommandHandler(
    IValidator<UpdateRecruitJobApplicationStatusSettingRequest> _validator,
    IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecruitJobApplicationStatusSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitJobApplicationStatusSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.RecruitJobApplicationStatusSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var recruitJobApplicationStatusSetting =
            await _recruitJobApplicationStatusSettingRepository.GetByIdAsync(request.RecruitJobApplicationStatusSetting
                .Id);
        if (recruitJobApplicationStatusSetting is null)
        {
            return new ServerResponse(Message: "Recruit JobApplication Status Setting Not Found");
        }

        // Map the request to the entity
        var recruitJobApplicationStatusSettingEntity =
            mapper.Map<RecruitJobApplicationStatusSetting>(request.RecruitJobApplicationStatusSetting);

        try
        {
            // Update the lead Source
            _recruitJobApplicationStatusSettingRepository.Update(recruitJobApplicationStatusSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit JobApplication Status Setting updated successfully",
            recruitJobApplicationStatusSetting);
    }
}