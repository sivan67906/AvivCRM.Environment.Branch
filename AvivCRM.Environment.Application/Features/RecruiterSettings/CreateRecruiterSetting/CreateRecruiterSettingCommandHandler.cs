#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Recruit;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.CreateRecruiterSetting;
internal class CreateRecruiterSettingCommandHandler(
    IValidator<CreateRecruiterSettingRequest> validator,
    IRecruiterSetting _recruiterSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateRecruiterSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateRecruiterSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.RecruiterSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var recruiterSettingEntity = mapper.Map<RecruiterSetting>(request.RecruiterSetting);

        try
        {
            _recruiterSettingRepository.Add(recruiterSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Recruiter Setting created successfully", recruiterSettingEntity);
    }
}