#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.UpdateRecruitGeneralSetting;
internal class UpdateRecruitGeneralSettingCommandHandler(
    IValidator<UpdateRecruitGeneralSettingRequest> _validator,
    IRecruitGeneralSetting _recruitGeneralSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecruitGeneralSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitGeneralSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.RecruitGeneralSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var recruitGeneralSetting =
            await _recruitGeneralSettingRepository.GetByIdAsync(request.RecruitGeneralSetting.Id);
        if (recruitGeneralSetting is null)
        {
            return new ServerResponse(Message: "Recruit General Setting Not Found");
        }

        // Map the request to the entity
        var recruitGeneralSettingEntity = mapper.Map<RecruitGeneralSetting>(request.RecruitGeneralSetting);

        try
        {
            // Update the lead Source
            _recruitGeneralSettingRepository.Update(recruitGeneralSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit General Setting updated successfully", recruitGeneralSettingEntity);
    }
}