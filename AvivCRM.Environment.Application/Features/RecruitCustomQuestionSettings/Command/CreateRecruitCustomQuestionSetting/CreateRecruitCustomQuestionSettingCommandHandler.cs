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

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.CreateRecruitCustomQuestionSetting;
internal class CreateRecruitCustomQuestionSettingCommandHandler(
    IValidator<CreateRecruitCustomQuestionSettingRequest> validator,
    IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruitCustomQuestionSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruitCustomQuestionSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruitCustomQuestionSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruitCustomQuestionSetting recruitCustomQuestionSettingEntity =
            mapper.Map<RecruitCustomQuestionSetting>(request.RecruitCustomQuestionSetting);

        try
        {
            _recruitCustomQuestionSettingRepository.Add(recruitCustomQuestionSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruit Custom Question Setting created successfully",
            recruitCustomQuestionSettingEntity);
    }
}