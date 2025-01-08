#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.GetAllApplication;
internal class GetAllApplicationQueryHandler(IApplication _applicationRepository, IMapper mapper)
    : IRequestHandler<GetAllApplicationQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllApplicationQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        var application = await _applicationRepository.GetAllAsync();
        if (application is null)
        {
            return new ServerResponse(Message: "No Application Found");
        }

        // Map the Application to the response
        var applicationResponse = mapper.Map<IEnumerable<GetApplication>>(application);
        if (applicationResponse is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        return new ServerResponse(true, "List of Applications", applicationResponse);
    }
}