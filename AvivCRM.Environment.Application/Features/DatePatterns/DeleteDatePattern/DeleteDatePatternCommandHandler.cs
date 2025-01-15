using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.DatePatterns.DeleteDatePattern;

internal class DeleteDatePatternCommandHandler(IDatePattern _datePatternRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteDatePatternCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteDatePatternCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var datePattern = await _datePatternRepository.GetByIdAsync(request.Id);
        if (datePattern is null) return new ServerResponse(Message: "DatePattern Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<DatePattern>(datePattern);

        try
        {
            // Delete DatePattern
            _datePatternRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "DatePattern deleted successfully", Data: delMapEntity);
    }
}
























