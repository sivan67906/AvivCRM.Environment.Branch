﻿using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Applicationss.DeleteApplication;
internal class DeleteApplicationCommandHandler(IApplication _applicationRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteApplicationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var application = await _applicationRepository.GetByIdAsync(request.Id);
        if (application is null) return new ServerResponse(Message: "Application Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<Applications>(application);

        try
        {
            // Delete Application
            _applicationRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Application deleted successfully", Data: application);
    }
}
