#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.DeleteTax;
internal class DeleteTaxCommandHandler(ITax _taxRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteTaxCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var tax = await _taxRepository.GetByIdAsync(request.Id);
        if (tax is null)
        {
            return new ServerResponse(Message: "Tax Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<Tax>(tax);

        try
        {
            // Delete tax
            _taxRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Tax deleted successfully", delMapEntity);
    }
}