#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.UpdateRecruitFooterSetting;
internal class UpdateRecruitFooterSettingCommandHandler(
    IValidator<UpdateRecruitFooterSettingRequest> _validator,
    IRecruitFooterSetting _recruitFooterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecruitFooterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitFooterSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.RecruitFooterSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        RecruitFooterSetting? recruitFooterSetting = await _recruitFooterSettingRepository.GetByIdAsync(request.RecruitFooterSetting.Id);
        if (recruitFooterSetting is null)
        {
            return new ServerResponse(Message: "Recruit Footer Setting Not Found");
        }

        // Map the request to the entity
        RecruitFooterSetting recruitFooterSettingEntity = mapper.Map<RecruitFooterSetting>(request.RecruitFooterSetting);

        try
        {
            // Update the lead Source
            _recruitFooterSettingRepository.Update(recruitFooterSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit Footer Setting updated successfully", recruitFooterSettingEntity);
    }
}