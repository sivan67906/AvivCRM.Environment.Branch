using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.CreateRecruitNotificationSetting;

internal class CreateRecruitNotificationSettingCommandHandler(IValidator<CreateRecruitNotificationSettingRequest> validator,
    IRecruitNotificationSetting _recruitNotificationSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateRecruitNotificationSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateRecruitNotificationSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.RecruitNotificationSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var recruitNotificationSettingEntity = mapper.Map<RecruitNotificationSetting>(request.RecruitNotificationSetting);

        try
        {
            _recruitNotificationSettingRepository.Add(recruitNotificationSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Recruit Notification Setting created successfully", Data: recruitNotificationSettingEntity);
    }
}











