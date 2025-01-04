using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.UpdateRecruitCustomQuestionSetting;

internal class UpdateRecruitCustomQuestionSettingCommandHandler(IValidator<UpdateRecruitCustomQuestionSettingRequest> _validator, IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateRecruitCustomQuestionSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateRecruitCustomQuestionSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.RecruitCustomQuestionSetting);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var recruitCustomQuestionSetting = await _recruitCustomQuestionSettingRepository.GetByIdAsync(request.RecruitCustomQuestionSetting.Id);
        if (recruitCustomQuestionSetting is null) return new ServerResponse(Message: "Recruit Custom Question Setting Not Found");

        // Map the request to the entity
        var recruitCustomQuestionSettingEntity = mapper.Map<RecruitCustomQuestionSetting>(request.RecruitCustomQuestionSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Recruit Custom Question Setting Updated Successfully", Data: recruitCustomQuestionSetting);
    }
}









