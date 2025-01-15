#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.CreateRecruitFooterSetting;
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
        var validate = await validator.ValidateAsync(request.RecruitFooterSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var recruitFooterSettingEntity = mapper.Map<RecruitFooterSetting>(request.RecruitFooterSetting);

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