using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.CreateRecruitJobApplicationStatusSetting;

internal class CreateRecruitJobApplicationStatusSettingCommandHandler(IValidator<CreateRecruitJobApplicationStatusSettingRequest> validator,
    IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateRecruitJobApplicationStatusSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateRecruitJobApplicationStatusSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.RecruitJobApplicationStatusSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var recruitJobApplicationStatusSettingEntity = mapper.Map<RecruitJobApplicationStatusSetting>(request.RecruitJobApplicationStatusSetting);

        try
        {
            _recruitJobApplicationStatusSettingRepository.Add(recruitJobApplicationStatusSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Recruit JobApplication Status Setting created successfully", Data: recruitJobApplicationStatusSettingEntity);
    }
}











