﻿using AvivCRM.Environment.Application.DTOs.Taskss;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Taskss.UpdateTask;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTasksRequest>
{
    public UpdateTaskCommandValidator()
    {
    }
}
