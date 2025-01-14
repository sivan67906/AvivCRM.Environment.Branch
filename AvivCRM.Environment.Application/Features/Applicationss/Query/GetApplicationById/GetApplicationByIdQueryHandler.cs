﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Query.GetApplicationById;
internal class GetApplicationByIdQueryHandler(IApplication applicationRepository, IMapper mapper)
    : IRequestHandler<GetApplicationByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Application by id
        Domain.Entities.Applications? application = await applicationRepository.GetByIdAsync(request.Id);
        if (application is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        // Map the entity to the response
        GetApplication? applicationResponse = mapper.Map<GetApplication>(application); // <DTO> (parameter)
        if (applicationResponse is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        return new ServerResponse(true, "List of Application", applicationResponse);
    }
}