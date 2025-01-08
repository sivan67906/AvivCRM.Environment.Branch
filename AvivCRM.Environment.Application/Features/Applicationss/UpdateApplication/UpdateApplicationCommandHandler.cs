#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.UpdateApplication;
internal class UpdateApplicationCommandHandler(
    IValidator<UpdateApplicationRequest> _validator,
    IApplication _applicationRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateApplicationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Application);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Application exists
        var application = await _applicationRepository.GetByIdAsync(request.Application.Id);
        if (application is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        // Map the request to the entity
        var applicationEntity = mapper.Map<Applications>(request.Application);

        try
        {
            // Update the Application
            _applicationRepository.Update(applicationEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Application updated successfully", applicationEntity);
    }
}