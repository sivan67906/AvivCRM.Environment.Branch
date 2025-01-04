using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.CreateRecruitCustomQuestionSetting;

internal class CreateRecruitCustomQuestionSettingCommandHandler(IValidator<CreateRecruitCustomQuestionSettingRequest> validator,
    IRecruitCustomQuestionSetting _recruitCustomQuestionSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateRecruitCustomQuestionSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateRecruitCustomQuestionSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.RecruitCustomQuestionSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var recruitCustomQuestionSettingEntity = mapper.Map<RecruitCustomQuestionSetting>(request.RecruitCustomQuestionSetting);

        try
        {
            _recruitCustomQuestionSettingRepository.Add(recruitCustomQuestionSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Recruit Custom Question Setting Created Succcessfully", Data: recruitCustomQuestionSettingEntity);
    }
}











