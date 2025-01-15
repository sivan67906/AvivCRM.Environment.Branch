#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.CreateRecruitJobApplicationStatusSetting;
internal class CreateRecruitJobApplicationStatusSettingCommandHandler(
    IValidator<CreateRecruitJobApplicationStatusSettingRequest> validator,
    IRecruitJobApplicationStatusSetting _recruitJobApplicationStatusSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruitJobApplicationStatusSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruitJobApplicationStatusSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruitJobApplicationStatusSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruitJobApplicationStatusSetting recruitJobApplicationStatusSettingEntity =
            mapper.Map<RecruitJobApplicationStatusSetting>(request.RecruitJobApplicationStatusSetting);

        try
        {
            _recruitJobApplicationStatusSettingRepository.Add(recruitJobApplicationStatusSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruit JobApplication Status Setting created successfully",
            recruitJobApplicationStatusSettingEntity);
    }
}