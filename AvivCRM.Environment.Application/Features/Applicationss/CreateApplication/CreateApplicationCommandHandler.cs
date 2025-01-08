#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.CreateApplication;
internal class CreateApplicationCommandHandler(
    IValidator<CreateApplicationRequest> _validator,
    IApplication _applicationRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateApplicationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.Application);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        var applicationEntity = mapper.Map<Applications>(request.Application);

        try
        {
            // Add the application
            _applicationRepository.Add(applicationEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Application created successfully", applicationEntity);
    }
}