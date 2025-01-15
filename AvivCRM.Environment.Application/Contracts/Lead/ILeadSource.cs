#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Lead;
public interface ILeadSource
{
    void Add(LeadSource leadSource);
    void Update(LeadSource leadSource);
    void Delete(LeadSource leadSource);
    Task<LeadSource?> GetByIdAsync(Guid id);
    Task<IEnumerable<LeadSource>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string leadSourceName);
}