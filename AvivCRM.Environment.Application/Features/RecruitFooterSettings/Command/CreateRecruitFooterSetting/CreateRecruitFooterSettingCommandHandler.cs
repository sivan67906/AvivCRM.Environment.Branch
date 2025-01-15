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

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.CreateRecruitFooterSetting;
internal class CreateRecruitFooterSettingCommandHandler(
    IValidator<CreateRecruitFooterSettingRequest> validator,
    IRecruitFooterSetting _recruitFooterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruitFooterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruitFooterSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.RecruitFooterSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        RecruitFooterSetting recruitFooterSettingEntity = mapper.Map<RecruitFooterSetting>(request.RecruitFooterSetting);

        try
        {
            _recruitFooterSettingRepository.Add(recruitFooterSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruit Footer Setting created successfully", recruitFooterSettingEntity);
    }
}