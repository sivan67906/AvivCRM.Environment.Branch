#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.UpdateRecruitCustomQuestionSetting;
internal class UpdateRecruitCustomQuestionSettingCommandHandler(
    IValidator<UpdateRecruitCustomQuestionSettingRequest> _validator,
    IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecruitCustomQuestionSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitCustomQuestionSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.RecruitCustomQuestionSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        RecruitCustomQuestionSetting? recruitCustomQuestionSetting =
            await _recruitCustomQuestionSettingRepository.GetByIdAsync(request.RecruitCustomQuestionSetting.Id);
        if (recruitCustomQuestionSetting is null)
        {
            return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");
        }

        // Map the request to the entity
        RecruitCustomQuestionSetting recruitCustomQuestionSettingEntity =
            mapper.Map<RecruitCustomQuestionSetting>(request.RecruitCustomQuestionSetting);

        try
        {
            // Update the lead Source
            _recruitCustomQuestionSettingRepository.Update(recruitCustomQuestionSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Recruit Custom Question Setting updated successfully",
            recruitCustomQuestionSettingEntity);
    }
}