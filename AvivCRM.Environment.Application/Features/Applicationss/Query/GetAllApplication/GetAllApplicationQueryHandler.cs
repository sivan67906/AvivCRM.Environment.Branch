#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Query.GetAllApplication;
internal class GetAllApplicationQueryHandler(IApplication _applicationRepository, IMapper mapper)
    : IRequestHandler<GetAllApplicationQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllApplicationQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        IEnumerable<Domain.Entities.Applications>? application = await _applicationRepository.GetAllAsync();
        if (application is null)
        {
            return new ServerResponse(Message: "No Application Found");
        }

        // Map the Application to the response
        IEnumerable<GetApplication>? applicationResponse = mapper.Map<IEnumerable<GetApplication>>(application);
        if (applicationResponse is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        return new ServerResponse(true, "List of Applications", applicationResponse);
    }
}