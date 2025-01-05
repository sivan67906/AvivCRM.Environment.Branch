using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.UpdateAttendanceSetting;
public class UpdateAttendanceSettingCommandValidator : AbstractValidator<UpdateAttendanceSettingRequest>
{
    public UpdateAttendanceSettingCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Client Id should not be empty");
        RuleFor(x => x.AttendanceSettingCode)
                    .NotEmpty().WithMessage("Attendance Setting Code not empty")
                    .MaximumLength(25).WithMessage("Attendance Setting Code must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Attendance Setting Code should not be less than 3 characters");
        RuleFor(x => x.AttendanceSettingName)
                    .NotEmpty().WithMessage("Attendance Setting Name not empty")
                    .MaximumLength(25).WithMessage("Attendance Setting Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Attendance Setting Name should not be less than 3 characters");

    }
}
