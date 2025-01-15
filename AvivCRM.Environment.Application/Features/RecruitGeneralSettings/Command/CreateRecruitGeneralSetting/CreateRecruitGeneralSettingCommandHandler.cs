#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Domain.Entities.Recruit;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Command.CreateRecruitGeneralSetting;
internal class CreateRecruitGeneralSettingCommandHandler(
    IValidator<CreateRecruitGeneralSettingRequest> validator,
    IRecruitGeneralSetting _recruitGeneralSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruitGeneralSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruitGeneralSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruitGeneralSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruitGeneralSetting recruitGeneralSettingEntity = mapper.Map<RecruitGeneralSetting>(request.RecruitGeneralSetting);

        try
        {
            _recruitGeneralSettingRepository.Add(recruitGeneralSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruit General Setting created successfully", recruitGeneralSettingEntity);
    }
}