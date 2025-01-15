#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.CreateRecruitNotificationSetting;
internal class CreateRecruitNotificationSettingCommandHandler(
    IValidator<CreateRecruitNotificationSettingRequest> validator,
    IRecruitNotificationSetting _recruitNotificationSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruitNotificationSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruitNotificationSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruitNotificationSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruitNotificationSetting recruitNotificationSettingEntity =
            mapper.Map<RecruitNotificationSetting>(request.RecruitNotificationSetting);

        try
        {
            _recruitNotificationSettingRepository.Add(recruitNotificationSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruit Notification Setting created successfully",
            recruitNotificationSettingEntity);
    }
}