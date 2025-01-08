#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.DeleteEmployee;
internal class DeleteEmployeeCommandHandler(IEmployee _employeeRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteEmployeeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var employee = await _employeeRepository.GetByIdAsync(request.Id);
        if (employee is null)
        {
            return new ServerResponse(Message: "Employee Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<Employee>(employee);

        try
        {
            // Delete Employee
            _employeeRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Employee deleted successfully", delMapEntity);
    }
}